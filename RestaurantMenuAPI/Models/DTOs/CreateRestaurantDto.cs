namespace RestaurantMenuAPI.Models.DTOs
{
    public record CreateRestaurantDto
        (
        string Email,
        string Password,
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
