namespace HikiCoffee.Utilities.Constants
{
    public class MessageConstants
    {
        public static string Success = "Success";
        public static string ErrorFound = "Error Found.";
        public static string UserAlreadyCreated = "User already created, please login.";
        public static string VerifyMail = "User already created, please verify your given Gmail.";
        public static string Invaliduser = "Invalid user. Please create account.";
        public static string MailSent = "Mail Sent";
        public static string UserCreatedverifyMail = "User created, Check mail. Click link and verify.";

        public static string UserConfirmMailError = "Email verification failed.";
        public static string UserDoesNotExist = "User Does Not Exist.";

        public static string NotFound = " Is Not Found.";

        public static string AddSuccess(string name)
        {
            return "Add " + name + " is success.";
        }

        public static string UpdateSuccess(string name)
        {
            return "Update " + name + " is success.";
        }

        public static string DeleteSuccess(string name)
        {
            return "Delete " + name + " is success.";
        }
    }
}
