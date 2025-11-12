using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.DTOs;

namespace RestaurantMenuAPI.Services.Interfaces
{
    public interface IRestaurantService
    {
        Restaurant? Validate(AuthDto dto);
        bool CheckIfExists(int restId);
        RestaurantDto Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto? GetById(int restId);
        void Remove(int restId);
        void Update(UpdateRestaurantDto dto, int restId);
        bool IsOpen(TimeSpan openingTime, TimeSpan closingTime, string openingDays);
        void RegisterVisit(int restId);

    }
}
