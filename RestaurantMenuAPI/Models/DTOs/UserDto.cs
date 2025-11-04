using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Models.DTOs
{
    public record UserDto(
        int Id,
        string Email,
        State State
        );
}
