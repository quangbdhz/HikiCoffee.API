using HikiCoffee.Application.CoffeeTables;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
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

            return Ok(result.Message);
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateCoffeeTable(int coffeeTableId, string nameCoffeeTable)
        {
            var result = await _coffeeTableService.UpdateCoffeeTable(coffeeTableId, nameCoffeeTable);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCoffeeTable(int coffeeTableId)
        {
            var result = await _coffeeTableService.DeleteCoffeeTable(coffeeTableId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
