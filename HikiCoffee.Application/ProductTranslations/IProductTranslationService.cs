using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ProductTranslations;
using HikiCoffee.ViewModels.ProductTranslations.ProductTranslationDataRequest;

namespace HikiCoffee.Application.ProductTranslations
{
    public interface IProductTranslationService
    {
        Task<ApiResult<bool>> AddProductTranslation(ProductTranslationCreateRequest request);

        Task<ApiResult<bool>> UpdateProductTranslation(ProductTranslationUpdateRequest request);

        Task<ApiResult<bool>> DeleteProductTranslation(int productTranslationId);

        Task<List<ProductTranslationManagementViewModel>> GetByProductId(int productId);

        Task<List<ProductTranslationManagementViewModel>> GetAllByLanguageId(int languageId);

        Task<List<ItemOderViewModel>> GetAllByCategoryId(int categoryId, int languageId);

    }
}
