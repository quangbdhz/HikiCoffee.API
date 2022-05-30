using HikiCoffee.Application.Products;
using HikiCoffee.ViewModels.Products.ProducDataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducService _producService;

        public ProductsController(IProducService producService)
        {
            _producService = producService;
        }

        [HttpGet("GetPagingProducts")]
        public async Task<IActionResult> GetPagingProducts([FromQuery] ProductPagingRequest productPagingRequest)
        {
            var products = await _producService.GetPagingProducts(productPagingRequest);
            return Ok(products);
        }


        [HttpGet("GetById/{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, int languageId)
        {
            var product = await _producService.GetById(productId, languageId);
            if(product == null)
                return NotFound();  
            return Ok(product);
        }

        [HttpGet("GetSeoAlias/{seoAliasProduct}")]
        public async Task<IActionResult> GetById(string seoAliasProduct)
        {
            var product = await _producService.GetBySeoAlias(seoAliasProduct);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct(ProductCreateRequest productCreateRequest)
        {
            var result = await _producService.AddProduct(productCreateRequest);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut("Update/{currentLanguageId}")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest, int currentLanguageId)
        {
            var result = await _producService.UpdateProduct(productUpdateRequest, currentLanguageId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPatch("AddViewCount/{productId}")]
        public async Task<IActionResult> AddViewCountProduct(int productId)
        {
            var result = await _producService.AddViewCountProduct(productId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("Delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _producService.DeleteProduct(productId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
