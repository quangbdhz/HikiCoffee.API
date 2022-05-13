using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HikiCoffeeDbContext _context;

        public CategoryService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetAll(string languageId)
        {

            var gender = new Gender() { NameGender = "Test", IsActive = true };

            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();

           

            var gendesr =  _context.UnitTranslations.ToListAsync();

            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };

            return await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.NameCategory,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }
    }
}
