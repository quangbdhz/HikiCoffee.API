using HikiCoffee.Data.EF;
using HikiCoffee.Data.Entities;
using HikiCoffee.Utilities.Constants;
using HikiCoffee.ViewModels.Common;
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
            var checkAddUnitTranslationVersionLanguageCurrent = await _context.UnitTranslations.FirstOrDefaultAsync(x => x.UnitId == request.UnitId && x.LanguageId == request.LanguageId);
            if (checkAddUnitTranslationVersionLanguageCurrent != null)
                return new ApiErrorResult<bool>("Unit Translation has version Language");

            var unitTranslation = new UnitTranslation() { NameUnit = request.NameUnit, LanguageId = request.LanguageId, MoreInfo = request.MoreInfo, UnitId = request.UnitId };
            await _context.UnitTranslations.AddAsync(unitTranslation);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>("Add UnitTranslation is success.");

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

                return new ApiSuccessResult<bool>("Update UnitTranslation is success;");
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>(ex.Message);
            }
        }
    }
}
