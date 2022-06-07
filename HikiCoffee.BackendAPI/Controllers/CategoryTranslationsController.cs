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

        [HttpGet("GetByCategoryId/{categoryTranslationId}")]
        public async Task<IActionResult> AddCategoryTranslation(int categoryTranslationId)
        {
            var result = await _categoryTranslationService.GetByCategoryId(categoryTranslationId);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategoryTranslation(CategoryTranslationCreateRequest request)
        {
            var result = await _categoryTranslationService.AddCategoryTranslation(request);

            return Ok(result.Message);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategoryTranslation(CategoryTranslationUpdateRequest request)
        {
            var result = await _categoryTranslationService.UpdateCategoryTranslation(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{categoryTranslationId}")]
        public async Task<IActionResult> DeleteCategoryTranslation(int categoryTranslationId)
        {
            var result = await _categoryTranslationService.DeleteCategoryTranslation(categoryTranslationId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
