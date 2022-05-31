using HikiCoffee.Application.UnitTranslations;
using HikiCoffee.ViewModels.UnitTraslations.UnitTranslationDataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitTranslationsController : ControllerBase
    {
        private readonly IUnitTranslationService _unitTranslationService;

        public UnitTranslationsController(IUnitTranslationService unitTranslationService)
        {
            _unitTranslationService = unitTranslationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddUnitTranslation(UnitTranslationCreateRequest request)
        {
            var result = await _unitTranslationService.AddUnitTranslation(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("Update/{currentLanguageId}")]
        public async Task<IActionResult> UpdateUnitTranslation(UnitTranslationUpdateRequest request, int currentLanguageId)
        {
            var result = await _unitTranslationService.UpdateUnitTranslation(request, currentLanguageId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
