
using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface IHappyHourRepository
    {
        int AddConfig(HappyHour newHappyHourConfig);
        void EditConfig(HappyHour editHappyHourConfig, int restId);
        HappyHour? GetByRestaurantId(int restId);
        List<HappyHour> GetAll();
        void Remove(int restId);
        void SetActive(int restId);


    }
}
