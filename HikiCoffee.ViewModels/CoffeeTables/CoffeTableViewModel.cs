using HikiCoffee.ViewModels.Statuses;

namespace HikiCoffee.ViewModels.CoffeeTables
{
    public class CoffeTableViewModel
    {
        public int Id { get; set; }

        public string NameCoffeeTable { get; set; }

        public DateTime? AppointmentTime { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public bool IsActive { get; set; }

        public StatusViewModel StatusViewModel { get; set; }

    }
}
