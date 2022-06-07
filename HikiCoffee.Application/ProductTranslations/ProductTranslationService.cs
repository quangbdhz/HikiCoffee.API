using HikiCoffee.Application.Common;
using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ProductTranslations;
using HikiCoffee.ViewModels.ProductTranslations.ProductTranslationDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.ProductTranslations
{
    public class ProductTranslationService : ConvertSeoAlias, IProductTranslationService
    {
        private readonly HikiCoffeeDbContext _context;

        public ProductTranslationService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddProductTranslation(ProductTranslationCreateRequest request)
        {
            var checkLanguage = await _context.Languages.FirstOrDefaultAsync(x => x.Id == request.LanguageId);
            if (checkLanguage == null)
                return new ApiErrorResult<bool>("Language" + MessageConstants.NotFound);

            var checkTheProductTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.ProductId && x.LanguageId == request.LanguageId);

            if (checkTheProductTranslation != null)
                return new ApiErrorResult<bool>("ProductTranslation version Language already exist.");

            var checkProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if (checkProduct == null)
                return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

            var productTranslation = new ProductTranslation() 
            { 
                ProductId = request.ProductId, 
                LanguageId = request.LanguageId, 
                Description = request.Description, 
                Details = request.Details, 
                NameProduct = request.NameProduct, 
                SeoDescription = request.SeoDescription, 
                SeoAlias = GetSeoAlias(request.NameProduct), 
                SeoTitle = request.SeoTitle 
            };
            await _context.ProductTranslations.AddAsync(productTranslation);
            await _context.SaveChangesAsync();

            foreach (var item in request.CategoryIds)
            {
                var productInCategory = new ProductInCategory() { CategoryId = item, ProductId = request.ProductId };
                await _context.ProductInCategories.AddAsync(productInCategory);
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<bool>("Add ProductTranslation is success.");
        }

        public async Task<ApiResult<bool>> DeleteProductTranslation(int productTranslationId)
        {
            try
            {
                var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.Id == productTranslationId);

                if (productTranslation == null)
                    return new ApiErrorResult<bool>("ProductTranslation" + MessageConstants.NotFound);

                _context.ProductTranslations.Remove(productTranslation);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete ProductTranslation is success.");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<ProductTranslationManagementViewModel>> GetByProductId(int productId)
        {
            var productTranslations = await _context.ProductTranslations.Where(x => x.ProductId == productId).Select(x => new ProductTranslationManagementViewModel()
            {
                 Id = x.Id,
                 Description = x.Description,
                 SeoDescription = x.SeoDescription,
                 Details = x.Details,
                 LanguageId = x.LanguageId,
                 NameProduct = x.NameProduct,
                 ProductId = x.ProductId,
                 SeoAlias = x.SeoAlias,
                 SeoTitle = x.SeoTitle
            }).ToListAsync();

            return productTranslations;
        }

        public async Task<ApiResult<bool>> UpdateProductTranslation(ProductTranslationUpdateRequest request)
        {
            try
            {
                var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.Id == request.ProductTranslationId);
                if (productTranslation == null)
                    return new ApiErrorResult<bool>("Product Translation" + MessageConstants.NotFound);

                productTranslation.NameProduct = request.NameProduct;
                productTranslation.Description = request.Description;
                productTranslation.SeoTitle = request.SeoTitle;
                productTranslation.SeoDescription = request.SeoDescription;
                productTranslation.Details = request.Details;
                productTranslation.SeoAlias = GetSeoAlias(request.NameProduct);
                await _context.SaveChangesAsync();

                while (true)
                {
                    var productInCategory = await _context.ProductInCategories.FirstOrDefaultAsync(x => x.ProductId == productTranslation.ProductId);
                    if (productInCategory == null)
                        break;

                    _context.ProductInCategories.Remove(productInCategory);
                    await _context.SaveChangesAsync();
                }

                foreach (int item in request.CategoryIds)
                {
                    var newProductInCategories = new ProductInCategory() { ProductId = productTranslation.ProductId, CategoryId = item };
                    await _context.ProductInCategories.AddAsync(newProductInCategories);
                    await _context.SaveChangesAsync();
                }

                return new ApiSuccessResult<bool>("Update Product is success");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
