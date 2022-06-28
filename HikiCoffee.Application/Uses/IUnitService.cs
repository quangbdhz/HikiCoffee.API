using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Uses;

namespace HikiCoffee.Application.Uses
{
    public interface IUnitService
    {
        Task<List<UnitViewModel>> GetAll(int languageId);

        Task<PagedResult<UnitManagementViewModel>> GetPagingUnitManagements(PagingRequestBase request);

        Task<ApiResult<UnitViewModel?>> GetById(int id, int languageId);

        Task<ApiResult<int>> AddUnit();

        Task<ApiResult<bool>> DeleteUnit(int id);
    }
}
