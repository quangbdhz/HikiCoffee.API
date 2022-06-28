using HikiCoffee.Application.ImportProducts;
using HikiCoffee.ViewModels.ImportProducts.ImportProductDataRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ImportProductsController : ControllerBase
    {
        private readonly IImportProductService _importProductService;

        public ImportProductsController(IImportProductService importProductService)
        {
            _importProductService = importProductService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var importProducts = await _importProductService.GetAll();
            return Ok(importProducts);
        }

        [HttpGet("GetById/{importProductId}")]
        public async Task<IActionResult> GetById(int importProductId)
        {
            var importProduct = await _importProductService.GetById(importProductId);
        
            if(!importProduct.IsSuccessed)
                return NotFound(importProduct.Message);

            return Ok(importProduct.ResultObj);
        }

        [HttpGet("GetDetailById/{importProductId}/{laguageId}")]
        public async Task<IActionResult> GetDetailById(int importProductId, int laguageId)
        {
            var importProduct = await _importProductService.GetDetailById(importProductId, laguageId);

            if (!importProduct.IsSuccessed)
                return NotFound(importProduct.Message);

            return Ok(importProduct.ResultObj);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddImportProduct(ImportProductCreateRequest request)
        {
            var result = await _importProductService.AddImportProduct(request);

            if(!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetPagingImportProductManagements")]
        public async Task<IActionResult> GetPagingImportProductManagements([FromQuery] PagingRequestImportProduct request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var importProducts = await _importProductService.GetPagingImportProductManagements(request);

            return Ok(importProducts);
        }

    }
}
