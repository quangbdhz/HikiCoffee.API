using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.UnitTranslations;
using HikiCoffee.ViewModels.UnitTraslations.UnitTranslationDataRequest;
using Microsoft.EntityFrameworkCore;

namespace HikiCoffee.Application.UnitTranslations
{
    public class UnitTranslationService : IUnitTranslationService
    {
        private readonly HikiCoffeeDbContext _context;

        public UnitTranslationService(HikiCoffeeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> AddUnitTranslation(UnitTranslationCreateRequest request)
        {
            var checkLanguage = await _context.Languages.FirstOrDefaultAsync(x => x.Id == request.LanguageId);
            if (checkLanguage == null)
                return new ApiErrorResult<bool>("Language" + MessageConstants.NotFound);

            var checkTheUnitTranslation = await _context.UnitTranslations.FirstOrDefaultAsync(x => x.UnitId == request.UnitId && x.LanguageId == request.LanguageId);
            if (checkTheUnitTranslation != null)
                return new ApiErrorResult<bool>("UnitTranslation version Language already exist.");

            var checkUnit = await _context.Uses.FirstOrDefaultAsync(x => x.Id == request.UnitId);

            if (checkUnit == null)
                return new ApiErrorResult<bool>("Unit" + MessageConstants.NotFound);


            var unitTranslation = new UnitTranslation() { NameUnit = request.NameUnit, LanguageId = request.LanguageId, MoreInfo = request.MoreInfo, UnitId = request.UnitId };
            await _context.UnitTranslations.AddAsync(unitTranslation);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add UnitTranslation is success.");

        }

        public async Task<ApiResult<bool>> DeleteUnitTranslation(int unitTranslationId)
        {
            try
            {
                var unitTranslation = await _context.UnitTranslations.SingleOrDefaultAsync(x => x.Id == unitTranslationId);

                if (unitTranslation == null)
                    return new ApiErrorResult<bool>("UnitTranslation" + MessageConstants.NotFound);

                _context.UnitTranslations.Remove(unitTranslation);

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Delete UnitTranslation is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }

        public async Task<List<UnitTranslationManagementViewModel>> GetAllUnitTranslation(int languageId)
        {
            var unitTranslations = await _context.UnitTranslations.Where(x => x.LanguageId == languageId).Select(x => new UnitTranslationManagementViewModel()
            {
                Id = x.Id,
                UnitId = x.UnitId,
                LanguageId = x.LanguageId,
                MoreInfo = x.MoreInfo,
                NameUnit = x.NameUnit
            }).ToListAsync();

            return unitTranslations;
        }

        public async Task<List<UnitTranslationManagementViewModel>> GetByUnitId(int unitId)
        {
            var unitTranslations = await _context.UnitTranslations.Where(x => x.UnitId == unitId).Select(x => new UnitTranslationManagementViewModel()
            {
                Id = x.Id,
                UnitId = x.UnitId,
                LanguageId = x.LanguageId,
                MoreInfo = x.MoreInfo,
                NameUnit = x.NameUnit
            }).ToListAsync();

            return unitTranslations;
        }

        public async Task<ApiResult<bool>> UpdateUnitTranslation(UnitTranslationUpdateRequest request, int currentLanguageId)
        {
            try
            {
                var checkLanguage = await _context.UnitTranslations.FirstOrDefaultAsync(x => x.UnitId == request.UnitId && x.LanguageId == request.LanguageId);
                if (checkLanguage != null && currentLanguageId != request.LanguageId)
                    return new ApiErrorResult<bool>("Unit Translation has version Language");

                var unitTranslation = await _context.UnitTranslations.SingleOrDefaultAsync(x => x.UnitId == request.UnitId && x.LanguageId == request.LanguageId);

                if (unitTranslation == null)
                    return new ApiErrorResult<bool>("UnitTranslation" + MessageConstants.NotFound);

                unitTranslation.NameUnit = request.NameUnit;
                unitTranslation.MoreInfo = request.MoreInfo;
                unitTranslation.LanguageId = request.LanguageId;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>("Update UnitTranslation is success.");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
