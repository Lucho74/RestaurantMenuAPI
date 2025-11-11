namespace RestaurantMenuAPI.Models.DTOs
{
    public record UpdateRestaurantDto
        (
        string Name,
        string? ImageUrl,
        string? Description,
        string? Number,
        string? Address,
        TimeSpan OpeningTime,
        TimeSpan ClosingTime,
        string OpeningDays
        );
}
