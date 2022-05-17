using HikiCoffee.Data.EF;
using HikiCoffee.ViewModels.Languages;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly HikiCoffeeDbContext _context;

        public LanguageService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageViewModel>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageViewModel()
            {
                Id = x.Id,
                NameLanguage = x.NameLanguage,
                Code = x.Code
            }).ToListAsync();

            return languages;
        }
    }
}
