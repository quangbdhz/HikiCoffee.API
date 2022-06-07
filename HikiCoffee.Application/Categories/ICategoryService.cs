using HikiCoffee.ViewModels.Categories;
using HikiCoffee.ViewModels.Categories.CategoryDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(int languageId);

        Task<CategoryViewModel> GetById(int languageId, int categoryId);

        Task<ApiResult<int>> AddCategory(CategoryCreateRequest request);

        Task<ApiResult<bool>> UpdateCategory(CategoryUpdateRequest request);

        Task<ApiResult<bool>> DeleteCategory(int categoryId);

        Task<PagedResult<CategoryManagementViewModel>> GetPagingCategoryManagements(PagingRequestBase request);

    }
}
