using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Supliers;
using HikiCoffee.ViewModels.Supliers.SuplierDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Supliers
{
    public class SuplierService : ISuplierService
    {
        private readonly HikiCoffeeDbContext _context;

        public SuplierService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddSuplier(SuplierCreateRequest request)
        {
            var suplier = new Suplier() { Address = request.Address, ContractDate = DateTime.Now, IsActive = true, Phone = request.Phone, NameSuplier = request.NameSuplier, Email = request.Email, MoreInfo = request.MoreInfo };
            await _context.Supliers.AddAsync(suplier);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add Suplier is success");
        }

        public async Task<ApiResult<bool>> DeleteSuplier(int suplierId)
        {
            try
            {
                var suplier = await _context.Supliers.SingleOrDefaultAsync(x => x.Id == suplierId);
                if(suplier == null)
                    return new ApiErrorResult<bool>("Suplier" + MessageConstants.NotFound);
                suplier.IsActive = !suplier.IsActive;

                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>("Delete Suplier is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<SuplierViewModel>> GetAll()
        {
            var querySuplier = from s in _context.Supliers select s;

            return await querySuplier.Select(x => new SuplierViewModel() { Id = x.Id, Address = x.Address, Phone = x.Phone, NameSuplier = x.NameSuplier, ContractDate = x.ContractDate, Email = x.Email, IsActive = x.IsActive, MoreInfo = x.MoreInfo }).ToListAsync();

        }

        public async Task<ApiResult<SuplierViewModel>> GetById(int suplierId)
        {
            try
            {
                var suplier = await _context.Supliers.SingleOrDefaultAsync(x => x.Id == suplierId);
                if (suplier == null)
                    return new ApiErrorResult<SuplierViewModel>("Suplier" + MessageConstants.NotFound);

                var suplierViewModel = new SuplierViewModel() { Id = suplier.Id, Address = suplier.Address, Phone = suplier.Phone, NameSuplier = suplier.NameSuplier, ContractDate = suplier.ContractDate, Email = suplier.Email, IsActive = suplier.IsActive, MoreInfo = suplier.MoreInfo };

                return new ApiSuccessResult<SuplierViewModel>() { ResultObj = suplierViewModel };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<SuplierViewModel>(ex.Message);
            }
        }

        public async Task<ApiResult<bool>> UpdateSuplier(SuplierUpdateRequest request)
        {
            try
            {
                var suplier = await _context.Supliers.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (suplier == null)
                    return new ApiErrorResult<bool>("Suplier" + MessageConstants.NotFound);

                suplier.Address = request.Address;
                suplier.Phone = request.Phone;
                suplier.Email = request.Email;
                suplier.NameSuplier = request.NameSuplier;
                suplier.MoreInfo = request.MoreInfo;

                await _context.SaveChangesAsync();
                return new ApiSuccessResult<bool>("Update Suplier is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
