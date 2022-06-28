using HikiCoffee.Application.Common;
using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.CategoryTranslations;
using HikiCoffee.ViewModels.CategoryTranslations.CategoryTranslationDataRequest;
using HikiCoffee.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.CategoryTranslations
{
    public class CategoryTranslationService : ConvertSeoAlias, ICategoryTranslationService
    {
        private readonly HikiCoffeeDbContext _context;

        public CategoryTranslationService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> AddCategoryTranslation(CategoryTranslationCreateRequest request)
        {
            var isLanguage = await _context.Languages.FirstOrDefaultAsync(x => x.Id == request.LanguageId);

            if (isLanguage == null)
                return new ApiErrorResult<int>("Language" + MessageConstants.NotFound);

            var checkTheCategoryTranslation = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.CategoryId && x.LanguageId == request.LanguageId);

            if (checkTheCategoryTranslation != null)
                return new ApiErrorResult<int>("CategoryTranslation version Language already exist.");

            var checkCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);

            if (checkCategory == null)
                return new ApiErrorResult<int>("Category" + MessageConstants.NotFound);

            var categoryTranslation = new CategoryTranslation()
            {
                CategoryId = request.CategoryId,
                LanguageId = request.LanguageId,
                NameCategory = request.NameCategory,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle,
                SeoAlias = GetSeoAlias(request.NameCategory)
            };

            await _context.CategoryTranslations.AddAsync(categoryTranslation);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(MessageConstants.AddSuccess("CategoryTranslation"));
        }

        public async Task<ApiResult<bool>> DeleteCategoryTranslation(int categoryTranslationId)
        {
            try
            {
                var categoryTranslation = await _context.CategoryTranslations.SingleOrDefaultAsync(x => x.Id == categoryTranslationId);

                if (categoryTranslation == null)
                    return new ApiErrorResult<bool>("CategoryTranslation" + MessageConstants.NotFound);

                _context.CategoryTranslations.Remove(categoryTranslation);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("CategoryTranslation"));
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<CategoryTranslationManagementViewModel>> GetAllCategoryTranslationByLanguageId(int languageId)
        {
            var categoryTranslations = await _context.CategoryTranslations.Where(x => x.LanguageId == languageId).Select(x => new CategoryTranslationManagementViewModel()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                LanguageId = x.LanguageId,
                SeoAlias = x.SeoAlias,
                NameCategory = x.NameCategory,
                SeoDescription = x.SeoDescription,
                SeoTitle = x.SeoTitle
            }).ToListAsync();

            return categoryTranslations;
        }

        public async Task<List<CategoryTranslationWithUrlViewModel>> GetAllCategoryTranslationWithUrlByLanguageId(int languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId 
                        where ct.LanguageId == languageId
                        select new { c, ct };

            return await query.Select(x => new CategoryTranslationWithUrlViewModel()
            {
                Id = x.ct.Id,
                CategoryId = x.ct.CategoryId,
                LanguageId = x.ct.LanguageId,
                SeoAlias = x.ct.SeoAlias,
                NameCategory = x.ct.NameCategory,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
                UrlImageCoverCategory = x.c.UrlImageCoverCategory
            }).ToListAsync();
        }

        public async Task<List<CategoryTranslationManagementViewModel>> GetByCategoryId(int categoryId)
        {
            var categoryTranslations = await _context.CategoryTranslations.Where(x => x.CategoryId == categoryId).Select(x => new CategoryTranslationManagementViewModel()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                LanguageId = x.LanguageId,
                SeoAlias = x.SeoAlias,
                NameCategory = x.NameCategory,
                SeoDescription = x.SeoDescription,
                SeoTitle = x.SeoTitle
            }).ToListAsync();

            return categoryTranslations;
        }

        public async Task<ApiResult<bool>> UpdateCategoryTranslation(CategoryTranslationUpdateRequest request)
        {
            try
            {
                var categoryTranslation = await _context.CategoryTranslations.SingleOrDefaultAsync(x => x.Id == request.Id);

                if (categoryTranslation == null)
                    return new ApiErrorResult<bool>("CategoryTranslation" + MessageConstants.NotFound);

                categoryTranslation.NameCategory = request.NameCategory;
                categoryTranslation.SeoDescription = request.SeoDescription;
                categoryTranslation.SeoTitle = request.SeoTitle;
                categoryTranslation.SeoAlias = GetSeoAlias(request.NameCategory);

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("CategoryTranslation"));
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
