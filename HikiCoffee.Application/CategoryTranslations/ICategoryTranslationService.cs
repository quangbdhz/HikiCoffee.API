using HikiCoffee.ViewModels.CategoryTranslations;
using HikiCoffee.ViewModels.CategoryTranslations.CategoryTranslationDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.CategoryTranslations
{
    public interface ICategoryTranslationService
    {
        Task<ApiResult<int>> AddCategoryTranslation(CategoryTranslationCreateRequest request);

        Task<ApiResult<bool>> UpdateCategoryTranslation(CategoryTranslationUpdateRequest request);

        Task<ApiResult<bool>> DeleteCategoryTranslation(int categoryTranslationId);

        Task<List<CategoryTranslationManagementViewModel>> GetByCategoryId(int categoryId);

        Task<List<CategoryTranslationManagementViewModel>> GetAllCategoryTranslationByLanguageId(int languageId);

        Task<List<CategoryTranslationWithUrlViewModel>> GetAllCategoryTranslationWithUrlByLanguageId(int languageId);
    }
}
