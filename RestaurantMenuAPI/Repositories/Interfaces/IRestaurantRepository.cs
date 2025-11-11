using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        bool CheckIfExists(int restId);
        int Create(Restaurant newRest);
        List<Restaurant> GetAll();
        Restaurant? GetById(int restId);
        void Remove(int restId);
        void Update(Restaurant updatedRest, int restId);
        void Disable(Restaurant rest);
        Restaurant? Validate(string email);
    }
}
