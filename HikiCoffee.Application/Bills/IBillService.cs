using HikiCoffee.ViewModels.Bills;
using HikiCoffee.ViewModels.Bills.BillDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.Bills
{
    public interface IBillService
    {
        Task<ApiResult<int>> AddBill(BillCreateRequest request);

        Task<ApiResult<bool>> MergeBill(MergeBillRequest request);

        Task<InfoBillCoffeeTableViewModel?> GetBillIdOfCoffeeTable(int coffeeTableId);

        Task<ApiResult<bool>> CheckOutBill(BillCheckOutRequest request);

        Task<PagedResult<InfoBillCoffeeTableViewModel>> GetAllBill(PagingRequestBase request);
    }
}
