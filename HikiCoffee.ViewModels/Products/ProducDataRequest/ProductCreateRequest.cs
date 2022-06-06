namespace HikiCoffee.ViewModels.Products.ProducDataRequest
{
    public class ProductCreateRequest
    {
        public string UrlImageCoverProduct { get; set; }

        public decimal Price { get; set; }

        public bool? IsFeatured { get; set; }
    }
}
