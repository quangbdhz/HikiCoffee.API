namespace HikiCoffee.ViewModels.Products.ProducDataRequest
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        public string UrlImageCoverProduct { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public bool? IsFeatured { get; set; }

        public string NameProduct { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public int LanguageId { get; set; }

        public IList<int> Categories { get; set; }
    }
}
