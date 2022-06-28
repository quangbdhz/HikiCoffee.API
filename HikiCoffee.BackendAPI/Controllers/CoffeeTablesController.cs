using HikiCoffee.Application.CoffeeTables;
using HikiCoffee.ViewModels.CoffeeTables.CoffeeTableDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CoffeeTablesController : ControllerBase
    {
        private readonly ICoffeeTableService _coffeeTableService;

        public CoffeeTablesController(ICoffeeTableService coffeeTableService)
        {
            _coffeeTableService = coffeeTableService;
        }

        [HttpGet("GetAll/{languageIdStatus}")]
        public async Task<IActionResult> GetAll(int languageIdStatus)
        {
            var result = await _coffeeTableService.GetAll(languageIdStatus);

            return Ok(result);
        }

        [HttpGet("GetAllCoffeeTaleManagements")]
        public async Task<IActionResult> GetAllCoffeeTaleManagements()
        {
            var result = await _coffeeTableService.GetAllCoffeeTaleManagements();

            return Ok(result);
        }

        [HttpGet("GetById/{coffeeTableId}/{languageIdStatus}")]
        public async Task<IActionResult> GetById(int languageIdStatus, int coffeeTableId)
        {
            var result = await _coffeeTableService.GetById(coffeeTableId, languageIdStatus);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCoffeeTable(string nameCoffeeTable)
        {
            var result = await _coffeeTableService.AddCoffeeTable(nameCoffeeTable);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoffeeTable(int coffeeTableId, string nameCoffeeTable)
        {
            var result = await _coffeeTableService.UpdateCoffeeTable(coffeeTableId, nameCoffeeTable);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("ChangeStatusCoffeeTable")]
        public async Task<IActionResult> ChangeStatusCoffeeTable(ChangeStatusCoffeeTableRequest request)
        {
            var result = await _coffeeTableService.ChangeStatusCoffeeTable(request);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoffeeTable(int coffeeTableId)
        {
            var result = await _coffeeTableService.DeleteCoffeeTable(coffeeTableId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("ChangeCoffeeTableIdInBill")]
        public async Task<IActionResult> ChangeCoffeeTableIdInBill(ChangeCoffeeTableIdInBillRequest request)
        {
            var result = await _coffeeTableService.ChangeCoffeeTableIdInBill(request);

            if (!result.IsSuccessed)    
                return BadRequest(result);

            return Ok(result);
        }
    }
}
