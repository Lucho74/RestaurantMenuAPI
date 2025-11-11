namespace RestaurantMenuAPI.Models.DTOs
{
    public record ProductDiscountDto
        (
        bool HasDiscount,
        int? DiscountPercentage,
        DateTime? DiscountStart,
        DateTime? DiscountEnd

        );
}
