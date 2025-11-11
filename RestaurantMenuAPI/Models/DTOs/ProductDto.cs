namespace RestaurantMenuAPI.Models.DTOs
{
    public record ProductDto
        (
        int Id,
        string Name,
        decimal Price,
        string? Description,
        string? ImageUrl,
        bool IsFeatured,
        bool HasDiscount,
        int? DiscountPercentage,
        decimal? DiscountPrice,
        DateTime? DiscountStart,
        DateTime? DiscountEnd,
        bool HasHappyHour,
        decimal? HappyHourPrice,
        int RestaurantId
        );

}
