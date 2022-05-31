using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.UnitTraslations.UnitTranslationDataRequest;

namespace HikiCoffee.Application.UnitTranslations
{
    public interface IUnitTranslationService
    {
        Task<ApiResult<bool>> AddUnitTranslation(UnitTranslationCreateRequest request);

        Task<ApiResult<bool>> UpdateUnitTranslation(UnitTranslationUpdateRequest request, int currentLanguageId);
    }
}
