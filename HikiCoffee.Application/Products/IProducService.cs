using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Products;
using HikiCoffee.ViewModels.Products.ProducDataRequest;

namespace HikiCoffee.Application.Products
{
    public interface IProducService
    {
        Task<PagedResult<ProductViewModel>> GetPagingProducts(ProductPagingRequest productPagingRequest);

        Task<PagedResult<ProductViewModel>> GetProductViewModelByOption(ProductPagingRequest productPagingRequest, int option);

        Task<ProductViewModel?> GetById(int id, int languageId);

        Task<ProductViewModel?> GetBySeoAlias(string seoAlias);

        Task<ApiResult<bool>> AddProduct(ProductCreateRequest productCreateRequest);

        Task<ApiResult<bool>> UpdateProduct(ProductUpdateRequest productUpdateRequest, int currentLanguageId);

        Task<ApiResult<bool>> AddViewCountProduct(int productId);

        Task<ApiResult<bool>> DeleteProduct(int productId);

    }
}
