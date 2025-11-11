namespace RestaurantMenuAPI.Models.DTOs
{
    public record CategoryWithProductsDto
        (
        int Id,
        string Name,
        string? Description,
        int RestaurantId,
        List<int> ProductIds
        );
}
