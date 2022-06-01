using HikiCoffee.Data.Entities;

namespace HikiCoffee.ViewModels.ImportProducts
{
    public class ImportProductViewModel
    {
        public int Id { get; set; }

        public DateTime DateImportProduct { get; set; }

        public int Quantity { get; set; }

        public int PriceImportProduct { get; set; }



        public AppUser AppUser { get; set; }

        public Product Product { get; set; }

        public Suplier Suplier { get; set; }
    }
}
