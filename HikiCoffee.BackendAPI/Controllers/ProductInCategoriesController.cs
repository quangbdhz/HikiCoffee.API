using HikiCoffee.Application.ProductInCategories;
using HikiCoffee.ViewModels.ProductInCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductInCategoriesController : ControllerBase
    {
        private readonly IProductInCategoryService _productInCategoryService;

        public ProductInCategoriesController(IProductInCategoryService productInCategoryService)
        {
            _productInCategoryService = productInCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategoryTranslation(ProductInCategoryCreateRequest request)
        {
            var result = await _productInCategoryService.AddProductInCategory(request);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{productId}/{categoryId}")]
        public async Task<IActionResult> AddCategoryTranslation(int productId, int categoryId)
        {
            var result = await _productInCategoryService.DeleteProductInCategory(productId, categoryId);

            return Ok(result.Message);
        }

        [HttpGet("GetCategoryOfProduct/{languageId}/{productId}")]
        public async Task<IActionResult> GetCategoryOfProduct(int languageId, int productId)
        {
            var result = await _productInCategoryService.GetCategoryOfProduct(languageId, productId);

            return Ok(result);        }

    }
}
