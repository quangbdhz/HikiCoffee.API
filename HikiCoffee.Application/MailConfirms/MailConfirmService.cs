using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.MailConfirms;
using HikiCoffee.ViewModels.Users;
using System.Net.Mail;

namespace HikiCoffee.Application.MailConfirms
{
    public class MailConfirmService : IMailConfirmService
    {
        public string GetMailBody(UserViewModel userViewModel)
        {
            string url = SystemConstants.DomainName + "/api/Users/ConfirmMail?userName=" + userViewModel.UserName;

            return string.Format(@"
                                <div style='text-align:center; background-color: #141414; width: 60%; margin: 0 auto;'>
                                   <a href='http://localhost:4200' target='_blank'>
                                      <img class='icon-image' style='width: 30%; padding-top: 10px;' alt='hikicomic'
                                         src='https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1644225980/icon-hiki_bj6dhz.png'>
                                   </a>
                                   <h1 style='color: #FFD60A; margin: 0; padding-top: 15px;'> Welcome to HikiComic </h1>
                                   <h3 style='color: white;'> Click below button for verify your Email </h3>
                                   <form method = 'post' action = '{0}' style='display: inline;'>
                                      <button type = 'submit' style = 'display:block; text-align: center; margin: 0 auto; font-weight: bold;
                                                                       background-color: #008CBA; font-size: 16px; border-radius: 10px;
                                                                       color: black; cursor: pointer; width: 80%;padding: 10px;'>
                                         Confirm Mail
                                      </button>
                                   </form>
                                   <br><h3 style='color: #FFD60A; padding-bottom: 10px; margin: 0px;'>HikiComic</h3>
                                   <p style='color:white; padding: 5px; margin: 0px; font-size: 80%;'>
                                      Contact: 1911-0443: <u style='color: #21b4d9'>tranquangbdhz@gmail.com</u>
                                   </p>
                                   <p style='margin: 0px; color: white; padding-bottom: 5px; font-size: 90%;'>
                                      Copyright (C) Hiki ALL Rights Reserved.
                                   </p>
                                </div>", url, userViewModel.UserName);
        }

        public async Task<string> SendMail(MailConfirmViewModel mailConfirmViewModel)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailConfirmViewModel.FromMailId);
                    mailConfirmViewModel.ToMailIds.ForEach(x => { mail.To.Add(x); });
                    mail.Subject = mailConfirmViewModel.Subject;
                    mail.Body = mailConfirmViewModel.Body;
                    mail.IsBodyHtml = mailConfirmViewModel.IsBodyHtml;
                    mailConfirmViewModel.Attachments.ForEach(x => { mail.Attachments.Add(new Attachment(x)); });

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new System.Net.NetworkCredential(mailConfirmViewModel.FromMailId, mailConfirmViewModel.FromMailIdPassword);

                        await smtp.SendMailAsync(mail);
                        return MessageConstants.MailSent;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
