using HikiCoffee.ViewModels.CategoryTranslations;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ProductInCategories;

namespace HikiCoffee.Application.ProductInCategories
{
    public interface IProductInCategoryService
    {
        Task<ApiResult<int>> AddProductInCategory(ProductInCategoryCreateRequest request);

        Task<ApiResult<bool>> DeleteProductInCategory(int productId, int categoryId);

        Task<List<CategoryTranslationManagementViewModel>> GetCategoryOfProduct(int languageId, int productId); 
    }
}
