using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User? Validate(string email, string password);
        bool CheckIfExists(int userId);
        int Create(User newUser);
        List<User> GetAll();
        User? GetById(int userId);
        void Remove(int userId);
        void Update(User updatedUser, int userId);
        void Disable(User user);
    }
}
