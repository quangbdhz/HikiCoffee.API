using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.ViewModels.Products.ProducDataRequest
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }

        public int? CategoryId { get; set; }

        public int LanguageId { get; set; }
    }
}
