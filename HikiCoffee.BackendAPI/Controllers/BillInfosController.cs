using HikiCoffee.Application.BillInfos;
using HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillInfosController : ControllerBase
    {
        private readonly IBillInfoService _billInfoService;

        public BillInfosController(IBillInfoService billInfoService)
        {
            _billInfoService = billInfoService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBillInfo(BillInfoCreateRequest request)
        {
            var result = await _billInfoService.AddBillInfo(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateQuantityBillInfo(BillInfoUpdateRequest request)
        {
            var result = await _billInfoService.UpdateQuantityBillInfo(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBillInfo(int id)
        {
            var result = await _billInfoService.DeleteBillInfo(id);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}
