using HikiCoffee.ViewModels.Products;

namespace HikiCoffee.ViewModels.BillInfos
{
    public class BillInfoViewModel
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Amount { get; set; }

        public ProductViewModel Product { get; set; }
    }
}
