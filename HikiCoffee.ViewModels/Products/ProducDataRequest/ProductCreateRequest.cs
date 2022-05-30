namespace HikiCoffee.ViewModels.Products.ProducDataRequest
{
    public class ProductCreateRequest
    {
        public string UrlImageCoverProduct { get; set; }

        public decimal Price { get; set; }

        public bool? IsFeatured { get; set; }

        public string NameProduct { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public int LanguageId { get; set; }

        public IList<int> CategoryIds { get; set; }
    }
}
