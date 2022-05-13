using HikiCoffee.ViewModels.Categories;

namespace HikiCoffee.Application.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
    }
}
