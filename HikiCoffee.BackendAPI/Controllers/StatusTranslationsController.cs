using HikiCoffee.Application.StatusTransaltions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTranslationsController : ControllerBase
    {
        private readonly IStatusTranslationService _statusTranslationService;

        public StatusTranslationsController(IStatusTranslationService statusTranslationService)
        {
            _statusTranslationService = statusTranslationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStatusTranslation(int statusId, string nameStatus, int languageId)
        {
            var result = await _statusTranslationService.AddStatusTranslation(statusId, nameStatus, languageId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


        [HttpDelete("Delete/{statusId}")]
        public async Task<IActionResult> DeleteStatusTranslation(int statusId)
        {
            var result = await _statusTranslationService.DeleteStatusTranslation(statusId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStatusTranslation(int id, string nameStatus)
        {
            var result = await _statusTranslationService.UpdateStatusTranslation(id, nameStatus);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("GetByStatusId")]
        public async Task<IActionResult> GetByStatusId(int statusId)
        {
            var result = await _statusTranslationService.GetByStatusId(statusId);


            return Ok(result);
        }

    }

}
