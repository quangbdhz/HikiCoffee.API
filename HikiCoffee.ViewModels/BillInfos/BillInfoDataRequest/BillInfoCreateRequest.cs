namespace HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest
{
    public class BillInfoCreateRequest
    {
        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }
    }
}
