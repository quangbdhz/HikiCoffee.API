namespace HikiCoffee.Data.Entities
{
    public class CoffeeTable
    {
        public int Id { get; set; }

        public string NameCoffeeTable { get; set; }


        public DateTime? AppointmentTime { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public bool IsActive { get; set; }



        public List<AppointmentSchedule> AppointmentSchedules { get; set; }

        public List<Bill> Bills { get; set; }
    }
}
