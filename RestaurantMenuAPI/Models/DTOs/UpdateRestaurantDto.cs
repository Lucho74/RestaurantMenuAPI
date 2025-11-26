namespace RestaurantMenuAPI.Models.DTOs
{
    public record UpdateRestaurantDto
        (
        string Name,
        string? Description,
        string? ImageUrl,
        string? Number,
        string? Address,
        TimeSpan OpeningTime,
        TimeSpan ClosingTime,
        string OpeningDays
        );
}
