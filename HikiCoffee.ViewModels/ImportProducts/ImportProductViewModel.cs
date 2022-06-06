using HikiCoffee.ViewModels.Products;
using HikiCoffee.ViewModels.Supliers;
using HikiCoffee.ViewModels.Users;

namespace HikiCoffee.ViewModels.ImportProducts
{
    public class ImportProductViewModel
    {
        public int Id { get; set; }

        public DateTime DateImportProduct { get; set; }

        public int Quantity { get; set; }

        public int PriceImportProduct { get; set; }

        public bool IsGetById { get; set; } = true;

        public UserViewModel User { get; set; }

        public ProductViewModel Product { get; set; }

        public SuplierViewModel Suplier { get; set; }
    }
}
