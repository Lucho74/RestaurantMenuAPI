using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Services.Interfaces
{
    public interface IHappyHourService
    {
        HappyHourDto AddConfig(ConfigHappyHourDto happyHourDto, int restId);
        void EditConfig(HappyHourDto dto, int restId);
        IEnumerable<HappyHourDto> GetAll();
        HappyHourDto? GetByRestaurantId(int restId);
        decimal? GetHappyHourPrice(Product product, int restId);
        void Remove(int restId);
        void SetActive (int restId);


    }
}
