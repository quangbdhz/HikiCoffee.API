using HikiCoffee.Data.Entities;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Statuses;

namespace HikiCoffee.Application.Statuses
{
    public interface IStatusService
    {
        Task<List<StatusViewModel>> GetAll(int languageId);

        Task<ApiResult<StatusViewModel?>> GetById(int statusId, int languageId);

        Task<PagedResult<StatusManagementViewModel>> GetPagingStatusManagements(PagingRequestBase request);

        Task<ApiResult<int>> AddStatus();

        Task<ApiResult<bool>> DeleteStatus(int statusId);
    }
}
