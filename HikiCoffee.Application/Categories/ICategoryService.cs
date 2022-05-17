using HikiCoffee.ViewModels.Categories;

namespace HikiCoffee.Application.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(int languageId);

        Task<CategoryViewModel> GetById(int languageId, int categoryId);



    }
}
