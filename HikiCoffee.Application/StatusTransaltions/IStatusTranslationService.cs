using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.StatusTranslations;

namespace HikiCoffee.Application.StatusTransaltions
{
    public interface IStatusTranslationService
    {
        Task<ApiResult<bool>> AddStatusTranslation(int statusId, string nameStatus, int languageId);

        Task<ApiResult<bool>> UpdateStatusTranslation(int id, string nameStatus);

        Task<ApiResult<bool>> DeleteStatusTranslation(int id);

        Task<List<StatusTranslationManagementViewModel>> GetByStatusId(int statusId);
    }
}
