using HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.BillInfos
{
    public interface IBillInfoService
    {
        Task<ApiResult<bool>> AddBillInfo(BillInfoCreateRequest request);

        Task<ApiResult<bool>> UpdateQuantityBillInfo(BillInfoUpdateRequest request);

        Task<ApiResult<bool>> DeleteBillInfo(int id);



    }
}
