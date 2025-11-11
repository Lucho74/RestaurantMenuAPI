namespace RestaurantMenuAPI.Models.DTOs
{
    public record CreateAndUpdateProductDto
        (
        string Name,
        decimal Price,
        string? ImageUrl,
        string? Description,
        bool IsFeatured,
        bool HasHappyHour
        );
}
