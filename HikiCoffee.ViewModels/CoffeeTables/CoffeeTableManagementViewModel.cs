namespace HikiCoffee.ViewModels.CoffeeTables
{
    public class CoffeeTableManagementViewModel
    {
        public int Id { get; set; }

        public string NameCoffeeTable { get; set; }

        public DateTime? AppointmentTime { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

        public string NameStatus { get; set; }
    }
}
