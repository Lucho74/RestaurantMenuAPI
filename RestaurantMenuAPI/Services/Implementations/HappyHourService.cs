using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Services.Implementations
{
    public class HappyHourService : IHappyHourService
    {
        private readonly IHappyHourRepository _happyHourRepository;
        public HappyHourService(IHappyHourRepository happyHourRepository)
        {
            _happyHourRepository = happyHourRepository;
        }

        public HappyHourDto AddConfig(ConfigHappyHourDto happyHourDto, int restId)
        {
            HappyHour newHappyHourConfig = new HappyHour()
            {
                RestaurantId = restId,
                DiscountPercentage = happyHourDto.DiscountPercentage,
                StartTime = happyHourDto.StartTime,
                EndTime = happyHourDto.EndTime,
            };
            int happyHourConfigId = _happyHourRepository.AddConfig(newHappyHourConfig);
            HappyHourDto createdHappyHourConfig = GetByRestaurantId(happyHourConfigId);
            return new HappyHourDto
            (
                createdHappyHourConfig.RestaurantId,
                createdHappyHourConfig.IsActive,
                createdHappyHourConfig.DiscountPercentage,
                createdHappyHourConfig.StartTime,
                createdHappyHourConfig.EndTime
            );
        }

        public void EditConfig(ConfigHappyHourDto dto, int restId)
        {
            HappyHour editedHappyHourConfig = new HappyHour()
            {
                DiscountPercentage = dto.DiscountPercentage,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
            };
            _happyHourRepository.EditConfig(editedHappyHourConfig, restId);
        }

        public HappyHourDto? GetByRestaurantId(int restId)
        {
            HappyHour? happyHour = _happyHourRepository.GetByRestaurantId(restId);
            if (happyHour == null)
            {
                return null;
            }
            return new HappyHourDto
            (
                happyHour.RestaurantId,
                happyHour.IsActive,
                happyHour.DiscountPercentage,
                happyHour.StartTime,
                happyHour.EndTime
            );
        }

        public decimal? GetHappyHourPrice(Product product, int restId)
        {
            if (product.HasHappyHour)
            {
                int discountPercentage = GetByRestaurantId(restId).DiscountPercentage;
                decimal happyHourPrice = Math.Round(product.Price * (1 - discountPercentage / 100m), 0);
                return happyHourPrice;
            }
            else return null;

        }

        public void Remove(int restId)
        {
            _happyHourRepository.Remove(restId);
        }

        public void SetActive(int restId)
        {
            _happyHourRepository.SetActive(restId);
        }

       
    }

}
