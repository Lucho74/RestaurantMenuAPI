using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateAndUpdateProductDto dto)
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            ProductDto createdProduct;
            try
            {
                createdProduct = _productService.Create(dto, restId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Producto creado con exito", createdProduct);
        }

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        public ActionResult<ProductDto> GetAllByCategory(int categoryId, int restId)
        {
            return Ok(_productService.GetAllByCategory(categoryId, restId));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<ProductDto> GetAllByRestaurant(int restId)
        {
            return Ok(_productService.GetAllByRestaurant(restId));
        }


        [HttpGet("{productId}")]
        [AllowAnonymous]
        public IActionResult GetOneById(int productId)
        {
            if (productId == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }
            ProductWithCategoriesDto? product = _productService.GetById(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(CreateAndUpdateProductDto dto, int productId)
        {
            _productService.Update(dto, productId);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productService.Remove(productId);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return NoContent();
        }

        [HttpPost("{productId}/category/{categoryId}")]
        public IActionResult AddCategoryToProduct(int productId, int categoryId)
        {
            _productService.AddCategoryToProduct(productId, categoryId);
            return NoContent();

        }
        [HttpDelete("{productId}/category/{categoryId}")]
        public IActionResult DeleteCategoryFromProduct(int productId, int categoryId)
        {
            _productService.DeleteCategoryFromProduct(productId, categoryId);
            return NoContent();
        }


            [HttpPut("{productId}/discount")]
        public IActionResult ApplyDiscount(ProductDiscountDto dto, int productId)
        {
            _productService.ApplyDiscount(dto, productId);
            return NoContent();
        }

        [HttpPut("increase-prices")]
        public IActionResult IncreaseAllPrices(IncreasePricesDto dto)
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            try
            {
                _productService.IncreaseAllPrices(restId, dto.Percentage);
                return Ok("Precios actualizados correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
