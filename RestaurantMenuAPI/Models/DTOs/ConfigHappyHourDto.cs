namespace RestaurantMenuAPI.Models.DTOs
{
    public record ConfigHappyHourDto
        (
        int DiscountPercentage,
        bool IsActive,
        TimeSpan StartTime,
        TimeSpan EndTime
        );
}
