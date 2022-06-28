using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Categories;
using HikiCoffee.ViewModels.Categories.CategoryDataRequest;
using HikiCoffee.ViewModels.Common;
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

        public async Task<ApiResult<int>> AddCategory(CategoryCreateRequest request)
        {
            var category = new Category() { IsActive = true, IsShowOnHome = request.IsShowOnHome, UrlImageCoverCategory = request.UrlImageCoverCategory, ParentId = request.ParentId, SortOrder = 0 };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>(category.Id) { Message = MessageConstants.AddSuccess("Category")};
        }

        public async Task<ApiResult<bool>> DeleteCategory(int categoryId)
        {
            try
            {
                var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == categoryId);

                if(category == null)
                    return new ApiErrorResult<bool>("Category" + MessageConstants.NotFound);

                category.IsActive = !category.IsActive;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>(MessageConstants.DeleteSuccess("Category"));
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
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

        public async Task<PagedResult<CategoryManagementViewModel>> GetPagingCategoryManagements(PagingRequestBase request)
        {
            var uses = await _context.Categories.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new CategoryManagementViewModel() 
            { 
                Id = x.Id, 
                IsShowOnHome = x.IsShowOnHome,
                UrlImageCoverCategory = x.UrlImageCoverCategory,
                IsActive =  x.IsActive,
                ParentId = x.ParentId, 
                SortOrder = x.SortOrder
            }).ToListAsync();

            int totalRow = uses.Count();

            var pagedResult = new PagedResult<CategoryManagementViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = uses
            };

            return pagedResult;
        }

        public async Task<ApiResult<bool>> UpdateCategory(CategoryUpdateRequest request)
        {
            try
            {
                var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

                if (category == null)
                    return new ApiErrorResult<bool>("Category" + MessageConstants.NotFound);

                category.ParentId = request.ParentId;
                category.IsShowOnHome = request.IsShowOnHome;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>(MessageConstants.UpdateSuccess("Category"));
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
