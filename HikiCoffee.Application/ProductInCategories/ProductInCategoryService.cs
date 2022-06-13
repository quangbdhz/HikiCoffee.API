using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.CategoryTranslations;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ProductInCategories;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.ProductInCategories
{
    public class ProductInCategoryService : IProductInCategoryService
    {
        private readonly HikiCoffeeDbContext _context;

        public ProductInCategoryService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddProductInCategory(ProductInCategoryCreateRequest request)
        {
            var productInCategory = new ProductInCategory() { CategoryId = request.CategoryId, ProductId = request.ProductId };

            await _context.ProductInCategories.AddAsync(productInCategory);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.AddSuccess("Product In Category"));
        }

        public async Task<ApiResult<bool>> DeleteProductInCategory(int productId, int categoryId)
        {
            var productInCategory = await _context.ProductInCategories.FirstOrDefaultAsync(x => x.ProductId == productId && x.CategoryId == categoryId);

            if(productInCategory == null)
                return new ApiErrorResult<bool>("ProductInCategory" + MessageConstants.NotFound);

            _context.ProductInCategories.Remove(productInCategory);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("ProductInCategory"));
        }

        public async Task<List<CategoryTranslationManagementViewModel>> GetCategoryOfProduct(int languageId, int productId)
        {
            var query = from p in _context.ProductInCategories where p.ProductId == productId
                        join ct in _context.CategoryTranslations on p.CategoryId equals ct.CategoryId 
                        where ct.LanguageId == languageId 
                        select ct;


            return await query.Select(x => new CategoryTranslationManagementViewModel()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                LanguageId = x.LanguageId,
                SeoAlias = x.SeoAlias,
                NameCategory = x.NameCategory,
                SeoDescription = x.SeoDescription,
                SeoTitle = x.SeoTitle
            }).ToListAsync();
        }
    }
}
