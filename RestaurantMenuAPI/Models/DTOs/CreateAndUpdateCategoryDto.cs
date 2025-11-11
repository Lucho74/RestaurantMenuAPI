namespace RestaurantMenuAPI.Models.DTOs
{
    public record CreateAndUpdateCategoryDto(
        string Name,
        string? Description
        );
}
