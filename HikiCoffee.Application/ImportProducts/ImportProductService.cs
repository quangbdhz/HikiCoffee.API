using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Categories;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ImportProducts;
using HikiCoffee.ViewModels.ImportProducts.ImportProductDataRequest;
using HikiCoffee.ViewModels.Products;
using HikiCoffee.ViewModels.Supliers;
using HikiCoffee.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.ImportProducts
{
    public class ImportProductService : IImportProductService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly HikiCoffeeDbContext _context;

        public ImportProductService(HikiCoffeeDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<ApiResult<bool>> AddImportProduct(ImportProductCreateRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserIdImportProduct.ToString());

            if (user == null)
                return new ApiErrorResult<bool>("User ImportProduct" + MessageConstants.NotFound);

            var checkUserStaff = await _userManager.GetRolesAsync(user);

            if(checkUserStaff == null)
                return new ApiErrorResult<bool>("User does not have permission.");

            bool isStaff = false;

            foreach (var item in checkUserStaff)
            {
                if(item.ToLower() == "staff") 
                { 
                    isStaff = true;
                }
            }

            if(isStaff ==  false)
                return new ApiErrorResult<bool>("User does not have permission.");


            var suplier = await _context.Supliers.FirstOrDefaultAsync(x => x.Id == request.SuplierId);
            if (suplier == null)
                return new ApiErrorResult<bool>("Suplier" + MessageConstants.NotFound);

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if (product == null)
                return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

            product.Stock += request.Quantity;
            await _context.SaveChangesAsync();

            var importProduct = new ImportProduct() { UserIdImportProduct = request.UserIdImportProduct, DateImportProduct = DateTime.Now, PriceImportProduct = request.PriceImportProduct, Quantity = request.Quantity, ProductId = request.ProductId, SuplierId = request.SuplierId };
            await _context.ImportProducts.AddAsync(importProduct);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add ImportProduct is success.");
        }

        public async Task<List<ImportProductViewModel>> GetAll()
        {
            var query = from i in _context.ImportProducts
                        join u in _context.Users on i.UserIdImportProduct equals u.Id
                        join p in _context.Products on i.ProductId equals p.Id
                        join s in _context.Supliers on i.SuplierId equals s.Id
                        select new { i, u, p, s };

            return await query.Select(x => new ImportProductViewModel()
            {
                Id = x.i.Id,
                DateImportProduct = x.i.DateImportProduct,
                PriceImportProduct = x.i.PriceImportProduct,
                Quantity = x.i.Quantity,
                User = new UserViewModel() { Id = x.u.Id },
                Product = new ProductViewModel(x.p.Id),
                Suplier = new SuplierViewModel() { Id = x.s.Id }
            }).ToListAsync();

        }

        public async Task<ApiResult<ImportProductViewModel?>> GetById(int importProductId)
        {
            var query = from i in _context.ImportProducts where i.Id == importProductId
                        join u in _context.Users on i.UserIdImportProduct equals u.Id
                        join p in _context.Products on i.ProductId equals p.Id
                        join s in _context.Supliers on i.SuplierId equals s.Id
                        select new { i, u, p, s };

            try
            {
                var importProductViewModel = await query.Select(x => 
                new ImportProductViewModel()
                {
                    Id = x.i.Id,
                    DateImportProduct = x.i.DateImportProduct,
                    PriceImportProduct = x.i.PriceImportProduct,
                    Quantity = x.i.Quantity,
                    User = new UserViewModel() { Id = x.u.Id },
                    Product = new ProductViewModel(x.p.Id),
                    Suplier = new SuplierViewModel() { Id = x.s.Id }
                }).FirstOrDefaultAsync();

                if(importProductViewModel == null)
                    return new ApiErrorResult<ImportProductViewModel?>("ImportProduct" + MessageConstants.NotFound);

                return new ApiSuccessResult<ImportProductViewModel?>(importProductViewModel);

            }
            catch(Exception ex)
            {
                return new ApiErrorResult<ImportProductViewModel?>(ex.Message);
            }
        }

        public async Task<ApiResult<ImportProductViewModel?>> GetDetailById(int importProductId, int languageId)
        {
            var query = from i in _context.ImportProducts
                        where i.Id == importProductId
                        join u in _context.Users on i.UserIdImportProduct equals u.Id
                        join p in _context.Products on i.ProductId equals p.Id
                        join s in _context.Supliers on i.SuplierId equals s.Id
                        select new { i, u, p, s };

            try
            {
                var importProductViewModel = await query.Select(x =>
                new ImportProductViewModel()
                {
                    Id = x.i.Id,
                    DateImportProduct = x.i.DateImportProduct,
                    PriceImportProduct = x.i.PriceImportProduct,
                    Quantity = x.i.Quantity,
                    IsGetById = false,
                    User = new UserViewModel() { Id = x.u.Id },
                    Product = new ProductViewModel(x.p.Id),
                    Suplier = new SuplierViewModel() { Id = x.s.Id }
                }).FirstOrDefaultAsync();

                if (importProductViewModel == null)
                    return new ApiErrorResult<ImportProductViewModel?>("ImportProduct" + MessageConstants.NotFound);

                #region query product
                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == importProductViewModel.Product.Id);

                if (product == null)
                    return new ApiErrorResult<ImportProductViewModel?>("Product" + MessageConstants.NotFound);

                var productTranslation = await _context.ProductTranslations.SingleOrDefaultAsync(x => x.ProductId == product.Id && x.LanguageId == languageId);

                if (productTranslation == null)
                    return new ApiErrorResult<ImportProductViewModel?>("ProductTranslation" + MessageConstants.NotFound);

                var queryCategoryViewModel = from pic in _context.ProductInCategories
                                             where pic.ProductId == product.Id
                                             join ct in _context.CategoryTranslations on pic.CategoryId equals ct.CategoryId
                                             where ct.LanguageId == languageId
                                             select new { pic, ct };

                var categoryViewModels = await queryCategoryViewModel.Select(x => new CategoryViewModel() { Id = x.ct.CategoryId, Name = x.ct.NameCategory, ParentId = 0 }).ToListAsync();

                importProductViewModel.Product = new ProductViewModel(product, productTranslation, categoryViewModels);
                #endregion

                #region query suplier
                var suplier = await _context.Supliers.SingleOrDefaultAsync(x => x.Id == importProductViewModel.Suplier.Id);
                if (suplier == null)
                    return new ApiErrorResult<ImportProductViewModel?>("Suplier" + MessageConstants.NotFound);

                var suplierViewModel = new SuplierViewModel() { Id = suplier.Id, Address = suplier.Address, Phone = suplier.Phone, NameSuplier = suplier.NameSuplier, ContractDate = suplier.ContractDate, Email = suplier.Email, IsActive = suplier.IsActive, MoreInfo = suplier.MoreInfo };

                importProductViewModel.Suplier = new SuplierViewModel() { Id = suplier.Id, Address = suplier.Address, Phone = suplier.Phone, NameSuplier = suplier.NameSuplier, ContractDate = suplier.ContractDate, Email = suplier.Email, IsActive = suplier.IsActive, MoreInfo = suplier.MoreInfo };
                #endregion

                #region query user
                var user = await _userManager.FindByIdAsync(importProductViewModel.User.Id.ToString());
                if (user == null)
                {
                    return new ApiErrorResult<ImportProductViewModel?>("User" + MessageConstants.NotFound);
                }
                var roles = await _userManager.GetRolesAsync(user);

                var gender = await _context.Genders.SingleOrDefaultAsync(x => x.Id == user.GenderId);

                importProductViewModel.User = new UserViewModel()
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    Dob = user.Dob,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Gender = gender != null ? gender.NameGender : "null",
                    Roles = roles
                };
                #endregion

                return new ApiSuccessResult<ImportProductViewModel?>(importProductViewModel);

            }
            catch (Exception ex)
            {
                return new ApiErrorResult<ImportProductViewModel?>(ex.Message);
            }
        }
    }
}
