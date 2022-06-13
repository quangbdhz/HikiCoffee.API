using HikiCoffee.Application.Products;
using HikiCoffee.ViewModels.Common;
using HikiCoffee.ViewModels.Products.ProducDataRequest;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetPagingProductManagements")]
        [Authorize]
        public async Task<IActionResult> GetPagingProductManagements([FromQuery] PagingRequestBase request)
        {
            var products = await _producService.GetPagingProductManagements(request);

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
        [Authorize]
        public async Task<IActionResult> AddProduct(ProductCreateRequest productCreateRequest)
        {
            var result = await _producService.AddProduct(productCreateRequest);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            if(result.ResultObj == 0)
                return NotFound(result.Message);

            return Ok(result.ResultObj);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var result = await _producService.UpdateProduct(productUpdateRequest);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPatch("AddViewCount/{productId}")]
        public async Task<IActionResult> AddViewCountProduct(int productId)
        {
            var result = await _producService.AddViewCountProduct(productId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await _producService.DeleteProduct(productId);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}
