namespace HikiCoffee.ViewModels.Users
{
    public class UserManagementViewModel
    {
        public Guid Id { get; set; }

        public string? UrlImageUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public DateTime Dob { get; set; }

        public string NameGender { get; set; }

        public bool IsActive { get; set; }

        //public string NameRole { get; set; }
    }
}
