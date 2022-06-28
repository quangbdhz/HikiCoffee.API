using HikiCoffee.ViewModels.Languages;

namespace HikiCoffee.Application.Languages
{
    public interface ILanguageService
    {
        Task<List<LanguageViewModel>> GetAll();
    }
}

