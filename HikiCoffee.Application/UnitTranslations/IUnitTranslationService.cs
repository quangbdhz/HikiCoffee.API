using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.UnitTranslations;
using HikiCoffee.ViewModels.UnitTraslations.UnitTranslationDataRequest;

namespace HikiCoffee.Application.UnitTranslations
{
    public interface IUnitTranslationService
    {
        Task<ApiResult<int>> AddUnitTranslation(UnitTranslationCreateRequest request);

        Task<ApiResult<bool>> UpdateUnitTranslation(UnitTranslationUpdateRequest request, int currentLanguageId);

        Task<ApiResult<bool>> DeleteUnitTranslation(int unitTranslationId);

        Task<List<UnitTranslationManagementViewModel>> GetByUnitId(int unitId);

        Task<List<UnitTranslationManagementViewModel>> GetAllUnitTranslation(int languageId);
    }
}
