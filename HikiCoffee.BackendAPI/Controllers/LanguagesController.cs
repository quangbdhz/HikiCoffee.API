using HikiCoffee.Application.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _languageService.GetAll();
            if(languages != null)
                return Ok(languages);

            return NotFound();
        }
    }
}
