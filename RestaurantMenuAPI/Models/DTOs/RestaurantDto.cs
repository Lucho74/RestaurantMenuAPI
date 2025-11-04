using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Models.DTOs
{
    public record RestaurantDto(
        int Id,
        string Email,
        string Name,
        string? ImageURL,
        string? Description,
        string? Number,
        string? Adress,
        State State


        );
}
