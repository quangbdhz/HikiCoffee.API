using HikiCoffee.Application.ProductTranslations;
using HikiCoffee.ViewModels.ProductTranslations.ProductTranslationDataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTranslationsController : ControllerBase
    {
        private readonly IProductTranslationService _productTranslationService;

        public ProductTranslationsController(IProductTranslationService productTranslationService)
        {
            _productTranslationService = productTranslationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProductTranslation(ProductTranslationCreateRequest request)
        {
            var result = await _productTranslationService.AddProductTranslation(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{productTranslationId}")]
        public async Task<IActionResult> DeleteProductTranslation(int productTranslationId)
        {
            var result = await _productTranslationService.DeleteProductTranslation(productTranslationId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateProductTranslation(ProductTranslationUpdateRequest request)
        {
            var result = await _productTranslationService.UpdateProductTranslation(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpGet("GetByProductId/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var result = await _productTranslationService.GetByProductId(productId);

            if (result.Count < 1)
                return NotFound("Product Translation Is Not Found.");

            return Ok(result);
        }

        [HttpGet("GetAllByLanguageId/{languageId}")]
        public async Task<IActionResult> GetAllByLanguageId(int languageId)
        {
            var result = await _productTranslationService.GetAllByLanguageId(languageId);

            if (result.Count < 1)
                return NotFound("Product Translation Is Not Found.");

            return Ok(result);
        }

        [HttpGet("GetAllByCategoryId/{categoryId}/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId, int languageId)
        {
            var result = await _productTranslationService.GetAllByCategoryId(categoryId, languageId);

            return Ok(result);
        }

    }
}
