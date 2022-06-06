using HikiCoffee.Application.Genders;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllForClient()
        {
            var genders = await _genderService.GetAllForClient();

            return Ok(genders);
        }

        [HttpGet("GetAllForManager")]
        public async Task<IActionResult> GetAllForManager()
        {
            var genders = await _genderService.GetAllForManager();

            return Ok(genders);
        }

        [HttpGet("GetById/{genderId}")]
        public async Task<IActionResult> GetById(int genderId)
        {
            var result = await _genderService.GetById(genderId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            if (result.ResultObj == null)
                return NotFound(result.Message);

            return Ok(result.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddGender(string nameGender)
        {
            var result = await _genderService.AddGender(nameGender);

            return Ok(result.ResultObj);
        }

        [HttpDelete("Delete/{genderId}")]
        public async Task<IActionResult> DeleteGender(int genderId)
        {
            var result = await _genderService.DeleteGender(genderId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGender(int genderId, string nameGender)
        {
            var result = await _genderService.UpdateGender(genderId, nameGender);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
