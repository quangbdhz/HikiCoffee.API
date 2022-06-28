using HikiCoffee.Application.BillInfos;
using HikiCoffee.ViewModels.BillInfos.BillInfoDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateQuantityBillInfo(BillInfoUpdateRequest request)
        {
            var result = await _billInfoService.UpdateQuantityBillInfo(request);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/{billId}/{productId}")]
        public async Task<IActionResult> DeleteBillInfo(int billId, int productId)
        {
            var result = await _billInfoService.DeleteBillInfo(billId, productId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAllBillInfoManagement/{billId}/{languageId}")]
        public async Task<IActionResult> GetAllBillInfoManagement(int billId, int languageId)
        {
            var billInfos = await _billInfoService.GetAllBillInfoManagement(billId, languageId);
           
            return Ok(billInfos);
        }

        [HttpGet("GetBillInfoByBillId/{billId}/{languageId}")]
        public async Task<IActionResult> GetBillInfoByBillId(int billId, int languageId)
        {
            var billInfos = await _billInfoService.GetBillInfoByBillId(billId, languageId);

            return Ok(billInfos);
        }
    }
}




