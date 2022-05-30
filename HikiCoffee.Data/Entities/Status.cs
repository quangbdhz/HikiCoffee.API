namespace HikiCoffee.Data.Entities
{
    public class Status
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public List<CoffeeTable> CoffeeTables { get; set; }

        public List<AppointmentSchedule> AppointmentSchedules { get; set; }

        public List<Bill> Bills { get; set; }

        public List<ImportProduct> ImportProducts { get; set; }

        public List<StatusTranslation> StatusTranslations { get; set; }

    }
}
