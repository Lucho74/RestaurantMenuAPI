namespace RestaurantMenuAPI.Models.DTOs
{
    public record ConfigHappyHourDto
        (
        int DiscountPercentage,
        TimeSpan StartTime,
        TimeSpan EndTime
        );
}
