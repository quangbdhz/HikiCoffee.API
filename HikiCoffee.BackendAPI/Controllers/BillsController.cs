using HikiCoffee.Application.Bills;
using HikiCoffee.ViewModels.Bills;
using HikiCoffee.ViewModels.Bills.BillDataRequest;
using HikiCoffee.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("CheckOut")]
        public async Task<IActionResult> CheckOut(BillCheckOutRequest request)
        {
            var result = await _billService.CheckOutBill(request);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("MergeBill")]
        public async Task<IActionResult> MergeBill(MergeBillRequest request)
        {
            var result = await _billService.MergeBill(request);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetBillIdOfCoffeeTable/{coffeeTableId}")]
        public async Task<IActionResult> GetBillIdOfCoffeeTable(int coffeeTableId)
        {
            var result = await _billService.GetBillIdOfCoffeeTable(coffeeTableId);

            if (result == null)
                return BadRequest(new InfoBillCoffeeTableViewModel() { BillId = 0 });

            return Ok(result);
        }

        [HttpGet("GetAllBill")]
        public async Task<IActionResult> GetAllBill([FromQuery] PagingRequestBase request)
        {
            var bills = await _billService.GetAllBill(request);

            return Ok(bills);
        }
    }
}
