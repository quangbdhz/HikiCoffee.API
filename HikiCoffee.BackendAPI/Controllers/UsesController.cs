using HikiCoffee.Application.Uses;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsesController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UsesController(IUnitService unitService)
        {
            _unitService = unitService;
        }


        [HttpGet("GetAll/{languageId}")]
        public async Task<IActionResult> GetAll(int languageId)
        {
            var unit = await _unitService.GetAll(languageId);

            return Ok(unit);
        }

        [HttpGet("GetById/{unitId}/{languageId}")]
        public async Task<IActionResult> GetById(int unitId, int languageId)
        {
            var result = await _unitService.GetById(unitId, languageId);

            if(!result.IsSuccessed)
                return BadRequest(result.Message);

            if (result.ResultObj == null)
                return NotFound();

            return Ok(result.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AdddUnit()
        {
            var result = await _unitService.AddUnit();

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{unitId}")]
        public async Task<IActionResult> DeleteUnit(int unitId)
        {
            var result = await _unitService.DeleteUnit(unitId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
