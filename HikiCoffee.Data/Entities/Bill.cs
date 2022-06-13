namespace HikiCoffee.Data.Entities
{
    public class Bill
    {
        public int Id { get; set; }

        public int CoffeeTabelId { get; set; }

        public Guid UserPaymentId { get; set; }

        public Guid? UserCustomerId { get; set; }

        public DateTime DateCheckIn { get; set; }

        public DateTime? DateCheckOut { get; set; }

        public double TotalPayPrice { get; set; }

        public int StatusId { get; set; }

        public CoffeeTable CoffeeTable { get; set; }

        public AppUser AppUser { get; set; }

        public Status Status { get; set; }

        public List<BillInfo> BillInfos { get; set; }
    }
}
