using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        public Restaurant? Validate(string email, string password);
        bool CheckIfExists(int restId);
        int Create(Restaurant newRest);
        List<Restaurant> GetAll();
        Restaurant? GetById(int restId);
        void Remove(int restId);
        void Update(Restaurant updatedRest, int restId);
        void Disable(Restaurant rest);
    }
}
