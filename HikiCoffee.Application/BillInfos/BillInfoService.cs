using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.BillInfos;
using HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest;
using HikiCoffee.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.BillInfos
{
    public class BillInfoService : IBillInfoService
    {
        private readonly HikiCoffeeDbContext _context;

        public BillInfoService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> AddBillInfo(BillInfoCreateRequest request)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == request.BillId);

                if (bill == null)
                    return new ApiErrorResult<int>("Bill" + MessageConstants.NotFound);

                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.ProductId);

                if(product == null)
                    return new ApiErrorResult<int>("Product" + MessageConstants.NotFound);

                if(product.Stock < 1)
                    return new ApiErrorResult<int>("Stock Product equals 0");

                if (product.Stock > 0)
                {
                    product.Stock = product.Stock - 1;
                    await _context.SaveChangesAsync();
                }

                var billInfo = new BillInfo() { BillId = request.BillId, Amount = request.Amount, Price = request.Price, ProductId = request.ProductId, Quantity = request.Quantity };
                await _context.BillInfos.AddAsync(billInfo);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(MessageConstants.AddSuccess("BillInfo"));
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> DeleteBillInfo(int billId, int productId)
        {
            try
            {
                var billInfo = await _context.BillInfos.SingleOrDefaultAsync(x => x.BillId == billId && x.ProductId == productId);

                if (billInfo == null)
                    return new ApiErrorResult<bool>("BillInfo" + MessageConstants.NotFound);

                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == billInfo.ProductId);

                if (product == null)
                    return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

                product.Stock += billInfo.Quantity;
                await _context.SaveChangesAsync();

                _context.BillInfos.Remove(billInfo);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete BillInfo is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<BillInfoManagementViewModel>?> GetAllBillInfoManagement(int billId, int languageId)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == billId);

            if (bill == null)
                return null;

            if(bill.StatusId == 1)
                return null;

            var query = from bi in _context.BillInfos
                        where bi.BillId == billId
                        join pt in _context.ProductTranslations on bi.ProductId equals pt.ProductId
                        where pt.LanguageId == languageId
                        select new { bi, pt };

            return await query.Select(x => new BillInfoManagementViewModel() 
            { 
                Id = x.bi.Id, 
                BillId = x.bi.BillId, 
                ProductId = x.bi.ProductId,
                Amount = x.bi.Amount, 
                Price = x.bi.Price, 
                Quantity = x.bi.Quantity,
                NameProduct = x.pt.NameProduct 
            }).ToListAsync();
        }

        public async Task<List<BillInfoManagementViewModel>?> GetBillInfoByBillId(int billId, int languageId)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.Id == billId);

            if (bill == null)
                return null;

            var query = from bi in _context.BillInfos
                        where bi.BillId == billId
                        join pt in _context.ProductTranslations on bi.ProductId equals pt.ProductId
                        where pt.LanguageId == languageId
                        select new { bi, pt };

            return await query.Select(x => new BillInfoManagementViewModel()
            {
                Id = x.bi.Id,
                BillId = x.bi.BillId,
                ProductId = x.bi.ProductId,
                Amount = x.bi.Amount,
                Price = x.bi.Price,
                Quantity = x.bi.Quantity,
                NameProduct = x.pt.NameProduct
            }).ToListAsync();
        }

        public async Task<ApiResult<bool>> UpdateQuantityBillInfo(BillInfoUpdateRequest request)
        {
            try
            {
                var billInfo = await _context.BillInfos.SingleOrDefaultAsync(x => x.BillId == request.BillId && x.ProductId == request.ProductId);

                if (billInfo == null)
                    return new ApiErrorResult<bool>("BillInfo" + MessageConstants.NotFound);

                var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.ProductId);

                if (product == null)
                    return new ApiErrorResult<bool>("Product" + MessageConstants.NotFound);

                if (product.Stock + billInfo.Quantity < request.Quantity)
                    return new ApiErrorResult<bool>($"Stock Product equals {request.Quantity - (product.Stock + billInfo.Quantity)}");

                product.Stock = product.Stock + billInfo.Quantity - request.Quantity;
                await _context.SaveChangesAsync();

                billInfo.Quantity = request.Quantity;
                billInfo.Amount = request.Amount;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update quantity BillInfo is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
