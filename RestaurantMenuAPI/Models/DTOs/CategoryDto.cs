namespace RestaurantMenuAPI.Models.DTOs
{
    public record CategoryDto
        (
        int Id,
        string Name,
        string? Description,
        int RestaurantId
        );
}
