using HikiCoffee.ViewModels.Categories;

namespace HikiCoffee.ViewModels.Products
{
    public class ProductViewModel
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

        public string NameProduct { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public string SeoAlias { get; set; }

        public int LanguageId { get; set; }

        public IList<CategoryViewModel>? Categories { get; set; }

        //public ProductViewModel(Product product, ProductTranslation productTranslation, IList<CategoryViewModel>? categories)
        //{
        //    Id = product.Id;
        //    UrlImageCoverProduct = product.UrlImageCoverProduct;
        //    DateCreated = product.DateCreated;
        //    Description = productTranslation.Description;
        //    IsActive = product.IsActive;
        //    Details = productTranslation.Details;
        //    IsFeatured = product.IsFeatured;
        //    LanguageId = productTranslation.LanguageId;
        //    NameProduct = productTranslation.NameProduct;
        //    OriginalPrice = product.OriginalPrice;
        //    Price = product.Price;
        //    SeoAlias = productTranslation.SeoAlias;
        //    SeoDescription = productTranslation.SeoDescription;
        //    SeoTitle = productTranslation.SeoTitle;
        //    Stock = product.Stock;
        //    ViewCount = product.ViewCount;
        //    Categories = categories;
        //}

        public ProductViewModel(int id)
        {
            Id = id;
        }

        public ProductViewModel()
        {

        }
    }
}
