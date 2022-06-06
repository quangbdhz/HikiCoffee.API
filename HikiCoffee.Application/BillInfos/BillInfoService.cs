using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
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

        public async Task<ApiResult<bool>> AddBillInfo(BillInfoCreateRequest request)
        {
            try
            {
                var bill = await _context.Bills.SingleOrDefaultAsync(x => x.Id == request.BillId);

                if (bill == null)
                    return new ApiErrorResult<bool>("Bill" + MessageConstants.NotFound);

                var billInfo = new BillInfo() { BillId = request.BillId, Amount = request.Amount, Price = request.Price, ProductId = request.ProductId, Quantity = request.Quantity };
                await _context.BillInfos.AddAsync(billInfo);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Add BillInfo is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> DeleteBillInfo(int id)
        {
            try
            {
                var billInfo = await _context.BillInfos.SingleOrDefaultAsync(x => x.Id == id);

                if (billInfo == null)
                    return new ApiErrorResult<bool>("BillInfo" + MessageConstants.NotFound);

                _context.BillInfos.Remove(billInfo);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete BillInfo is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> UpdateQuantityBillInfo(BillInfoUpdateRequest request)
        {
            try
            {
                var billInfo = await _context.BillInfos.SingleOrDefaultAsync(x => x.Id == request.Id);

                if (billInfo == null)
                    return new ApiErrorResult<bool>("BillInfo" + MessageConstants.NotFound);

                billInfo.Quantity = request.Quantity;
                billInfo.Price = request.Price;
                billInfo.Price = request.Amount;

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
