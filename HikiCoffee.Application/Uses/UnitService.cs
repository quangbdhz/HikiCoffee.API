using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Uses;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.Uses
{
    public class UnitService : IUnitService
    {
        private readonly HikiCoffeeDbContext _context;

        public UnitService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddUnit()
        {
            var unit = new Unit() { IsActive = true };

            await _context.Uses.AddAsync(unit);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add Unit is success.");
        }

        public async Task<ApiResult<bool>> DeleteUnit(int id)
        {
            try
            {
                var unit = await _context.Uses.SingleOrDefaultAsync(x => x.Id == id);
                if (unit == null)
                    return new ApiErrorResult<bool>("Unit" + MessageConstants.NotFound);

                unit.IsActive = !unit.IsActive;

                return new ApiSuccessResult<bool>("Delete Unit is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<UnitViewModel>> GetAll(int languageId)
        {
            var query = from u in _context.Uses join ut in _context.UnitTranslations on u.Id equals ut.UnitId where ut.LanguageId == languageId select new { u, ut };

            return await query.Select(x => new UnitViewModel() { Id = x.u.Id, NameUnit = x.ut.NameUnit, MoreInfo = x.ut.MoreInfo, IsActive = x.u.IsActive, LanguageId = x.ut.LanguageId }).ToListAsync();
        }

        public async Task<ApiResult<UnitViewModel?>> GetById(int id, int languageId)
        {
            try
            {
                var unit = await _context.Uses.SingleOrDefaultAsync(x => x.Id == id);

                if (unit == null)
                    return new ApiErrorResult<UnitViewModel?>("Unit" + MessageConstants.NotFound);

                var unitTranslation = await _context.UnitTranslations.SingleOrDefaultAsync(x => x.UnitId == id && x.LanguageId == languageId);

                if (unitTranslation == null)
                    return new ApiErrorResult<UnitViewModel?>("UnitTranslation" + MessageConstants.NotFound);

                var unitViewModel = new UnitViewModel() { Id = unit.Id, NameUnit = unitTranslation.NameUnit, MoreInfo = unitTranslation.MoreInfo, IsActive = unit.IsActive, LanguageId = unitTranslation.LanguageId };

                return new ApiSuccessResult<UnitViewModel?>(unitViewModel);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<UnitViewModel?>(ex.Message);
            }
        }

    }
}
