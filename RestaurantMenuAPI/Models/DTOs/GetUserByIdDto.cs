using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Models.DTOs
{
    public record GetUserByIdDto
        (
        int Id,
        string Email,
        State State
        );

}

