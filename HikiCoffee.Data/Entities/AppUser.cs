using Microsoft.AspNetCore.Identity;

namespace HikiCoffee.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public string? UrlImageUser { get; set; }

        public string? MoreInfo { get; set; }

        public bool IsActive { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public List<AppointmentSchedule> AppointmentSchedules { get; set; }

        public List<Bill> Bills { get; set; }

        public List<ImportProduct> ImportProducts { get; set; }

        //public List<Cart> Carts { get; set; }

        //public List<Order> Orders { get; set; }

        //public List<Transaction> Transactions { get; set; }
    }
}
