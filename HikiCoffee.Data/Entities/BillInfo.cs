namespace HikiCoffee.Data.Entities
{
    public class BillInfo
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public Bill Bill { get; set; }

        public Product Product { get; set; }

    }
}
