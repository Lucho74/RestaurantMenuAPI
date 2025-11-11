using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService, IConfiguration config)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(CreateRestaurantDto dto)
        {
            RestaurantDto createdRest;
            try
            {
                createdRest = _restaurantService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Creado con exito", createdRest);
        }

        [HttpGet]
        public ActionResult<RestaurantDto> GetAll()
        {
            return Ok(_restaurantService.GetAll());
        }

        [HttpGet("{restId}")]
        public IActionResult GetOneById(int restId)
        {
            if (restId == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }

            RestaurantDto? rest = _restaurantService.GetById(restId);

            if (rest == null)
            {
                return NotFound();
            }

            return Ok(rest);
        }

        [HttpPut("{restId}")]
        public IActionResult UpdateUser(UpdateRestaurantDto dto, int restId)
        {
            _restaurantService.Update(dto, restId);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _restaurantService.Remove(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("me")]
        public ActionResult<RestaurantDto> GetUserInfo()
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            RestaurantDto restaurant = _restaurantService.GetById(restId)!;
            return Ok(restaurant);
        }
    }
}
