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

        public async Task<List<CategoryViewModel>> GetAll(int languageId)
        {
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

        public async Task<CategoryViewModel> GetById(int languageId, int categoryId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == categoryId
                        select new { c, ct };

            var category = await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.NameCategory,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();

            if (category != null)
                return category;

            return new CategoryViewModel() { Id = 0, Name = "Category Is Not Available"};
        }
    }
}
