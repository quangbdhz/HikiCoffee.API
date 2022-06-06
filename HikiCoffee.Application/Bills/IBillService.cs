using HikiCoffee.ViewModels.Bills.BillDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.Bills
{
    public interface IBillService
    {
        Task<ApiResult<int>> AddBill(BillCreateRequest request);

        Task<ApiResult<bool>> CheckOutBill(int billId, double totalPayPrice);
    }
}
