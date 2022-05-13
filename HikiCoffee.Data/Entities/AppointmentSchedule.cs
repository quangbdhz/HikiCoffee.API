namespace HikiCoffee.Data.Entities
{
    // cuoc hen
    public class AppointmentSchedule
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int CoffeeTableId { get; set; }


        public DateTime AppointmentTime { get; set; }

        public DateTime ExpirationTime { get; set; }

        public string MoreInfo { get; set; }

        public AppUser AppUser { get; set; }

        public CoffeeTable CoffeeTable { get; set; }

    }
}
