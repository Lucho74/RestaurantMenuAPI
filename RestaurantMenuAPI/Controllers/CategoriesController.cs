using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Services.Implementations;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateAndUpdateCategoryDto dto)
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            CategoryDto createdCategory;
            try
            {
                createdCategory = _categoryService.Create(dto, restId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Categoría creada con exito", createdCategory);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<CategoryDto> GetAllByRestaurant(int restId)
        {
            return Ok(_categoryService.GetAllByRestaurant(restId));
        }

        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public ActionResult<CategoryDto> GetAllByProduct(int productId)
        {
            return Ok(_categoryService.GetAllByProduct(productId));
        }

        [HttpGet("{categoryId}")]
        [AllowAnonymous]
        public IActionResult GetOneById(int categoryId)
        {
            if (categoryId == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }
            CategoryWithProductsDto? category = _categoryService.GetById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(CreateAndUpdateCategoryDto dto, int categoryId)
        {
            _categoryService.Update(dto, categoryId);
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                _categoryService.Remove(categoryId);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return NoContent();
        }
    }
}
