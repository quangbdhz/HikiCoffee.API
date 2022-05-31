using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Uses;

namespace HikiCoffee.Application.Uses
{
    public interface IUnitService
    {
        Task<List<UnitViewModel>> GetAll(int languageId);

        Task<ApiResult<UnitViewModel?>> GetById(int id, int languageId);

        Task<ApiResult<bool>> AddUnit();

        Task<ApiResult<bool>> DeleteUnit(int id);
    }
}
