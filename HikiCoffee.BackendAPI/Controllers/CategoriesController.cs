using HikiCoffee.Application.Categories;
using HikiCoffee.ViewModels.Categories.CategoryDataRequest;
using HikiCoffee.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace HikiCoffee.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int languageId)
        {
            var categories = await _categoryService.GetAll(languageId);
            return Ok(categories);
        }

        [HttpGet("GetById/{languageId}/{categoryId}")]
        public async Task<IActionResult> GetById(int languageId, int categoryId)
        {
            var categories = await _categoryService.GetById(languageId, categoryId);

            if (categories.Id != 0)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpGet("GetPagingCategoryManagements")]
        public async Task<IActionResult> GetPagingCategoryManagements([FromQuery] PagingRequestBase request)
        {
            var categories = await _categoryService.GetPagingCategoryManagements(request);

            return Ok(categories);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory(CategoryCreateRequest request)
        {
            var result = await _categoryService.AddCategory(request);

            return Ok(result.ResultObj);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateRequest request)
        {
            var result = await _categoryService.UpdateCategory(request);

            if (!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("Delete/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategory(categoryId);

            if(!result.IsSuccessed)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

    }
}
