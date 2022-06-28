using HikiCoffee.ViewModels.CoffeeTables;
using HikiCoffee.ViewModels.CoffeeTables.CoffeeTableDataRequest;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.CoffeeTables
{
    public interface ICoffeeTableService
    {
        Task<List<CoffeTableViewModel>> GetAll(int languageIdStatus);

        Task<List<CoffeeTableManagementViewModel>> GetAllCoffeeTaleManagements();

        Task<ApiResult<CoffeTableViewModel>> GetById(int coffeeTableId, int languageIdStatus);

        Task<ApiResult<int>> AddCoffeeTable(string nameCoffeeTable);

        Task<ApiResult<bool>> UpdateCoffeeTable(int coffeeTableId, string nameCoffeeTable);

        Task<ApiResult<bool>> ChangeStatusCoffeeTable(ChangeStatusCoffeeTableRequest request);

        Task<ApiResult<bool>> DeleteCoffeeTable(int coffeeTableId);

        Task<ApiResult<bool>> ChangeCoffeeTableIdInBill(ChangeCoffeeTableIdInBillRequest request);

    }
}
