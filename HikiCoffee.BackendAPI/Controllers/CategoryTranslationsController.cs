using HikiCoffee.Application.CategoryTranslations;
using HikiCoffee.ViewModels.CategoryTranslations.CategoryTranslationDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTranslationsController : ControllerBase
    {
        private readonly ICategoryTranslationService _categoryTranslationService;

        public CategoryTranslationsController(ICategoryTranslationService categoryTranslationService)
        {
            _categoryTranslationService = categoryTranslationService;
        }

        [HttpGet("GetByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var result = await _categoryTranslationService.GetByCategoryId(categoryId);

            return Ok(result);
        }

        [HttpGet("GetAllCategoryTranslationByLanguageId/{languageId}")]
        public async Task<IActionResult> GetAllCategoryTranslationByLanguageId(int languageId)
        {
            var result = await _categoryTranslationService.GetAllCategoryTranslationByLanguageId(languageId);

            return Ok(result);
        }

        [HttpGet("GetAllCategoryTranslationWithUrlByLanguageId/{languageId}")]
        public async Task<IActionResult> GetAllCategoryTranslationWithUrlByLanguageId(int languageId)
        {
            var result = await _categoryTranslationService.GetAllCategoryTranslationWithUrlByLanguageId(languageId);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategoryTranslation(CategoryTranslationCreateRequest request)
        {
            var result = await _categoryTranslationService.AddCategoryTranslation(request);

            return Ok(result);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategoryTranslation(CategoryTranslationUpdateRequest request)
        {
            var result = await _categoryTranslationService.UpdateCategoryTranslation(request);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("Delete/{categoryTranslationId}")]
        public async Task<IActionResult> DeleteCategoryTranslation(int categoryTranslationId)
        {
            var result = await _categoryTranslationService.DeleteCategoryTranslation(categoryTranslationId);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
