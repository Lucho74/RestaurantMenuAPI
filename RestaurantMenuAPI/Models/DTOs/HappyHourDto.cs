namespace RestaurantMenuAPI.Models.DTOs
{
    public record HappyHourDto
        (
        int RestaurantId,
        bool IsActive,
        int DiscountPercentage,
        TimeSpan StartTime,
        TimeSpan EndTime
        );
}
