namespace HikiCoffee.ViewModels.BillInfos
{
    public class BillInfoManagementViewModel
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public string NameProduct { get; set; }
    }
}
