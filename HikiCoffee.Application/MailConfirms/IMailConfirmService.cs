using HikiCoffee.ViewModels.MailConfirms;
using HikiCoffee.ViewModels.Users;

namespace HikiCoffee.Application.MailConfirms
{
    public interface IMailConfirmService
    {
        Task<string> SendMail(MailConfirmViewModel mailConfirmViewModel);

        string GetMailBody(UserViewModel userViewModel);
    }
}
