using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Services.Implementations;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/happyhour")]
    [ApiController]
    [Authorize]
    public class HappyHourController : ControllerBase
    {
        private readonly IHappyHourService _happyHourService;
        public HappyHourController(IHappyHourService happyHourService)
        {
            _happyHourService = happyHourService;
        }

        [HttpPost]
        public IActionResult AddConfig(ConfigHappyHourDto dto)
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            HappyHourDto createdHappyHour;
            try
            {
                createdHappyHour = _happyHourService.AddConfig(dto, restId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Creado con exito", createdHappyHour);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<HappyHourDto> GetAll()
        {
            return Ok(_happyHourService.GetAll());
        }

        [HttpGet("{restId}")]
        [AllowAnonymous]
        public IActionResult GetByRestaurantId(int restId)
        {
            if (restId == 0)
            {
                return BadRequest("El ID ingresado debe ser distinto de 0");
            }
            HappyHourDto? happyHour = _happyHourService.GetByRestaurantId(restId);
            if (happyHour == null)
            {
                return NotFound();
            }
            return Ok(happyHour);
        }

        [HttpPut("{restId}")]
        public IActionResult EditConfig(HappyHourDto dto)
        {
            int restId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("id"))!.Value);
            _happyHourService.EditConfig(dto, restId);
            return NoContent();
        }

        [HttpDelete("{restId}")]
        public IActionResult Remove(int restId)
        {
            try
            {
                _happyHourService.Remove(restId);
            }
            catch (Exception ex)
            {
                BadRequest(ex);
            }
            return NoContent();
        }

        [HttpPut("{productId}/active")]
        public IActionResult SetActive(int restId)
        {
            _happyHourService.SetActive(restId);
            return NoContent();
        }



    }

}
