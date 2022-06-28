namespace HikiCoffee.Data.Entities
{
    public class ImportProduct
    {
        public int Id { get; set; }

        public Guid UserIdImportProduct { get; set; }

        public DateTime DateImportProduct { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int PriceImportProduct { get; set; }

        public int SuplierId { get; set; }


        public AppUser AppUser { get; set; }

        public Product Product { get; set; }

        public Suplier Suplier { get; set; }

    }
}
