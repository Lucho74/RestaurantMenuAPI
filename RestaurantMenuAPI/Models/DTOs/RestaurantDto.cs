using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Models.DTOs
{
    public record RestaurantDto(
        int Id,
        string Email,
        string Name,
        string? ImageUrl,
        string? Description,
        string? Number,
        string? Address,
        int Views,
        TimeSpan OpeningTime,
        TimeSpan ClosingTime,
        string OpeningDays,
        bool IsOpen,
        State State


        );
}
