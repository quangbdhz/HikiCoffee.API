using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Supliers;
using HikiCoffee.ViewModels.Supliers.SuplierDataRequest;

namespace HikiCoffee.Application.Supliers
{
    public interface ISuplierService
    {
        Task<List<SuplierViewModel>> GetAll();

        Task<List<SuplierViewModel>> GetAllSuplierManagements();

        Task<ApiResult<SuplierViewModel>> GetById(int suplierId);

        Task<ApiResult<int>> AddSuplier(SuplierCreateRequest request);

        Task<ApiResult<bool>> UpdateSuplier(SuplierUpdateRequest request);

        Task<ApiResult<bool>> DeleteSuplier(int suplierId);


    }
}
