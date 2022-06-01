using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.ImportProducts;
using HikiCoffee.ViewModels.ImportProducts.ImportProductDataRequest;
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

            return await query.Select(x => new ImportProductViewModel() { Id = x.i.Id, DateImportProduct = x.i.DateImportProduct, PriceImportProduct = x.i.PriceImportProduct, Quantity = x.i.Quantity, AppUser = x.u, Product = x.p, Suplier = x.s }).ToListAsync();

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
                var importProductViewModel = await query.Select(x => new ImportProductViewModel() { Id = x.i.Id, DateImportProduct = x.i.DateImportProduct, PriceImportProduct = x.i.PriceImportProduct, Quantity = x.i.Quantity, AppUser = x.u, Product = x.p, Suplier = x.s }).FirstOrDefaultAsync();

                if(importProductViewModel == null)
                    return new ApiErrorResult<ImportProductViewModel?>("ImportProduct" + MessageConstants.NotFound);

                return new ApiSuccessResult<ImportProductViewModel?>(importProductViewModel);

            }
            catch(Exception ex)
            {
                return new ApiErrorResult<ImportProductViewModel?>(ex.Message);
            }
        }
    }
}
