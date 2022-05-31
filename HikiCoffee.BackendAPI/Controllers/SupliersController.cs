using HikiCoffee.Application.Supliers;
using HikiCoffee.ViewModels.Supliers.SuplierDataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupliersController : ControllerBase
    {
        private readonly ISuplierService _suplierService;

        public SupliersController(ISuplierService suplierService)
        {
            _suplierService = suplierService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supliers = await _suplierService.GetAll();
            return Ok(supliers);
        }

        [HttpGet("GetById/{suplierId}")]
        public async Task<IActionResult> GetById(int suplierId)
        {
            var result = await _suplierService.GetById(suplierId);

            if (result.ResultObj == null)
                return NotFound("Get Suplier is not found");

            return Ok(result.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSuplier(SuplierCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _suplierService.AddSuplier(request);

            if (!result.IsSuccessed)
                return BadRequest();

            return Ok(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSuplier(SuplierUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _suplierService.UpdateSuplier(request);

            if (!result.IsSuccessed)
                return BadRequest();

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{suplierId}")]
        public async Task<IActionResult> DeleteSuplier(int suplierId)
        {
            var result = await _suplierService.DeleteSuplier(suplierId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}
