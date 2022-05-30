using HikiCoffee.Application.Common;
using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Categories;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Products;
using HikiCoffee.ViewModels.Products.ProducDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HikiCoffee.Application.Products
{
    public class ProductService : ConvertSeoAlias, IProducService
    {
        private readonly HikiCoffeeDbContext _context;

        public ProductService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetPagingProducts(ProductPagingRequest productPagingRequest)
        {
            return await GetProductViewModelByOption(productPagingRequest, 2);

        }

        public async Task<ProductViewModel?> GetById(int id, int languageId)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return null;

            var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.ProductId == id && x.LanguageId == languageId);

            if (productTranslation == null)
                return null;

            var queryCategoryViewModel = from pic in _context.ProductInCategories
                                         where pic.ProductId == product.Id
                                         join ct in _context.CategoryTranslations on pic.CategoryId equals ct.CategoryId
                                         where ct.LanguageId == languageId
                                         select new { pic, ct };

            var categoryViewModels = await queryCategoryViewModel.Select(x => new CategoryViewModel() { Id = x.ct.CategoryId, Name = x.ct.NameCategory, ParentId = 0 }).ToListAsync();

            return new ProductViewModel(product, productTranslation, categoryViewModels);
        }

        public async Task<ProductViewModel?> GetBySeoAlias(string seoAlias)
        {
            seoAlias = WebUtility.UrlDecode(seoAlias);
            var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.SeoAlias == seoAlias);

            if (productTranslation == null)
                return null;

            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productTranslation.ProductId);

            if (product == null)
                return null;

            var queryCategoryViewModel = from pic in _context.ProductInCategories
                                         where pic.ProductId == product.Id
                                         join ct in _context.CategoryTranslations on pic.CategoryId equals ct.CategoryId
                                         where ct.LanguageId == productTranslation.LanguageId
                                         select new { pic, ct };

            var categoryViewModels = await queryCategoryViewModel.Select(x => new CategoryViewModel() { Id = x.ct.CategoryId, Name = x.ct.NameCategory, ParentId = 0 }).ToListAsync();

            return new ProductViewModel(product, productTranslation, categoryViewModels);
        }

        public async Task<PagedResult<ProductViewModel>> GetProductViewModelByOption(ProductPagingRequest productPagingRequest, int option)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == productPagingRequest.LanguageId
                        select new { p, pt, pic, c };

            //option == 1 admin show all product
            if (option == 1)
            {
                query = query.Where(x => x.p.IsActive == true);
            }
            //client show product is not delete

            if (!string.IsNullOrEmpty(productPagingRequest.Keyword))
                query = query.Where(x => x.pt.NameProduct.Contains(productPagingRequest.Keyword));

            if (productPagingRequest.CategoryId != 0 && productPagingRequest.CategoryId != null)
            {
                query = query.Where(p => p.pic.CategoryId == productPagingRequest.CategoryId);
            }

            var data = await query.Skip((productPagingRequest.PageIndex - 1) * productPagingRequest.PageSize).Take(productPagingRequest.PageSize)
                    .Select(x => new ProductViewModel(x.p, x.pt, null)).ToListAsync();

            int totalRow = await query.CountAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = productPagingRequest.PageSize,
                PageIndex = productPagingRequest.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<ApiResult<bool>> AddProduct(ProductCreateRequest productCreateRequest)
        {
            var product = new Product() { UrlImageCoverProduct = productCreateRequest.UrlImageCoverProduct, Price = productCreateRequest.Price, OriginalPrice = productCreateRequest.Price, Stock = 0, ViewCount = 0, DateCreated = DateTime.Now, IsActive = true, IsFeatured = productCreateRequest.IsFeatured };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var productTranslation = new ProductTranslation() { ProductId = product.Id, LanguageId = productCreateRequest.LanguageId, Description = productCreateRequest.Description, Details = productCreateRequest.Details, NameProduct = productCreateRequest.NameProduct, SeoDescription = productCreateRequest.SeoDescription, SeoAlias = GetSeoAlias(productCreateRequest.NameProduct), SeoTitle = productCreateRequest.SeoTitle };
            await _context.ProductTranslations.AddAsync(productTranslation);
            await _context.SaveChangesAsync();

            foreach (var item in productCreateRequest.CategoryIds)
            {
                var productInCategory = new ProductInCategory() { CategoryId = item, ProductId = product.Id };
                await _context.ProductInCategories.AddAsync(productInCategory);
                await _context.SaveChangesAsync();
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateProduct(ProductUpdateRequest productUpdateRequest, int currentLanguageId)
        {
            try
            {
                var checkLanguage = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productUpdateRequest.Id && x.LanguageId == productUpdateRequest.LanguageId);
                if (checkLanguage != null && currentLanguageId != productUpdateRequest.LanguageId)
                    return new ApiErrorResult<bool>("Product Translation has version Language");

                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productUpdateRequest.Id);
                if (product == null)
                    return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

                product.UrlImageCoverProduct = productUpdateRequest.UrlImageCoverProduct;
                product.Price = productUpdateRequest.Price;
                product.OriginalPrice = productUpdateRequest.OriginalPrice;
                product.IsFeatured = productUpdateRequest.IsFeatured;
                await _context.SaveChangesAsync();

                var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.ProductId == product.Id && x.LanguageId == currentLanguageId);
                if (productTranslation == null)
                    return new ApiErrorResult<bool>("Product Translation" + MessageConstants.NotFound);

                productTranslation.NameProduct = productUpdateRequest.NameProduct;
                productTranslation.Description = productUpdateRequest.Description;
                productTranslation.SeoTitle = productUpdateRequest.SeoTitle;
                productTranslation.SeoDescription = productUpdateRequest.SeoDescription;
                productTranslation.Details = productUpdateRequest.Details;
                productTranslation.SeoAlias = GetSeoAlias(productUpdateRequest.NameProduct);
                productTranslation.LanguageId = productUpdateRequest.LanguageId;
                await _context.SaveChangesAsync();

                while (true)
                {
                    var productInCategory = await _context.ProductInCategories.FirstOrDefaultAsync(x => x.ProductId == productUpdateRequest.Id);
                    if (productInCategory == null)
                        break;

                    _context.ProductInCategories.Remove(productInCategory);
                    await _context.SaveChangesAsync();
                }

                foreach(int item in productUpdateRequest.Categories)
                {
                    var newProductInCategories = new ProductInCategory() { ProductId = productUpdateRequest.Id, CategoryId = item };
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

        public async Task<ApiResult<bool>> AddViewCountProduct(int productId)
        {
            try
            {
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);
                if (product == null)
                    return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

                product.ViewCount += 1;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Add ViewCount Product is success");
            }
            catch(Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> DeleteProduct(int productId)
        {
            try
            {
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == productId);
                if (product == null)
                    return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

                product.IsActive = !product.IsActive;
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete Product is success");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
