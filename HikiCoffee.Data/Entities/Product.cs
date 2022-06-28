namespace HikiCoffee.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string UrlImageCoverProduct { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Stock { get; set; }

        public int ViewCount { get; set; }

        public DateTime DateCreated { get; set; }

        public bool? IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public int? UnitId { get; set; }

        public Unit? Unit { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<BillInfo> BillInfos { get; set; }

        public List<ImportProduct> ImportProducts { get; set; }
    }
}
