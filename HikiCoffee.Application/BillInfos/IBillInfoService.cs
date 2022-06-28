using HikiCoffee.ViewModels.BillInfos;
using HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.BillInfos
{
    public interface IBillInfoService
    {
        Task<ApiResult<int>> AddBillInfo(BillInfoCreateRequest request);

        Task<ApiResult<bool>> UpdateQuantityBillInfo(BillInfoUpdateRequest request);

        Task<ApiResult<bool>> DeleteBillInfo(int billId, int productId);

        Task<List<BillInfoManagementViewModel>?> GetAllBillInfoManagement(int billId, int languageId);

        Task<List<BillInfoManagementViewModel>?> GetBillInfoByBillId(int billId, int languageId);

    }
}
