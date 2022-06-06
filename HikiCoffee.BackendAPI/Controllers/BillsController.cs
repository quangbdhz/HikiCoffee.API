using HikiCoffee.Application.Bills;
using HikiCoffee.ViewModels.Bills.BillDataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddBill(BillCreateRequest request)
        {
            var result = await _billService.AddBill(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.ResultObj);
        }

        [HttpPatch("CheckOut")]
        public async Task<IActionResult> CheckOut(int billId, double totalPayPrice)
        {
            var result = await _billService.CheckOutBill(billId, totalPayPrice);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
