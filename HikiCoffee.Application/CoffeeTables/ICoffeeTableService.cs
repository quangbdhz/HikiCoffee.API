using HikiCoffee.ViewModels.CoffeeTables;
using HikiCoffee.ViewModels.Common;

namespace HikiCoffee.Application.CoffeeTables
{
    public interface ICoffeeTableService
    {
        Task<List<CoffeTableViewModel>> GetAll(int languageIdStatus);

        Task<ApiResult<CoffeTableViewModel>> GetById(int coffeeTableId, int languageIdStatus);

        Task<ApiResult<bool>> AddCoffeeTable(string nameCoffeeTable);

        Task<ApiResult<bool>> UpdateCoffeeTable(int coffeeTableId, string nameCoffeeTable);

        Task<ApiResult<bool>> DeleteCoffeeTable(int coffeeTableId);
    }
}
