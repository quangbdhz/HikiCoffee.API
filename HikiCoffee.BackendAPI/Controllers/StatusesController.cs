using HikiCoffee.Application.Statuses;
using HikiCoffee.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusesController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("GetAll/{languageId}")]
        public async Task<IActionResult> GetAll(int languageId)
        {
            var statuses = await _statusService.GetAll(languageId);

            return Ok(statuses);
        }

        [HttpGet("GetById/{statusId}/{languageId}")]
        public async Task<IActionResult> GetById(int statusId, int languageId)
        {
            var result = await _statusService.GetById(statusId, languageId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            if (result.ResultObj == null)
                return NotFound();

            return Ok(result.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStatus()
        {
            var result = await _statusService.AddStatus();

            return Ok(result.ResultObj);
        }

        [HttpDelete("Delete/{statusId}")]
        public async Task<IActionResult> DeleteUnit(int statusId)
        {
            var result = await _statusService.DeleteStatus(statusId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("GetPagingStatusManagements")]
        public async Task<IActionResult> GetPagingStatusManagements([FromQuery] PagingRequestBase request)
        {
            var statuses = await _statusService.GetPagingStatusManagements(request);

            return Ok(statuses);
        }
    }
}
