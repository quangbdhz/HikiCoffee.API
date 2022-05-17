using HikiCoffee.Application.Categories;
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
    }
}
