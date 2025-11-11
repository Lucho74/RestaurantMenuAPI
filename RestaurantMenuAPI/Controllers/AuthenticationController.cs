using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IConfiguration _config;
        public AuthenticationController(IRestaurantService restaurantService, IConfiguration config)
        {
            _restaurantService = restaurantService;
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthDto dto)
        {
            Restaurant? rest = _restaurantService.Validate(dto);

            if (rest is null)
            {
                return Unauthorized();
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));

            var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
            new Claim("id", rest.Id.ToString()),
            new Claim("email", rest.Email),
            new Claim("name", rest.Name)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signature
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return Ok(tokenToReturn);

        }
    }
}
