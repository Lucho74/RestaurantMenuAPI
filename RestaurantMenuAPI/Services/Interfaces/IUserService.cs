using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.DTOs;

namespace RestaurantMenuAPI.Services.Interfaces
{
    public interface IUserService
    {
        User? Validate(string email, string password);
        bool CheckIfExists(int userId);
        UserDto Create(CreateAndUpdateUserDto dto);
        IEnumerable<UserDto> GetAll();
        GetUserByIdDto? GetById(int userId);
        void Remove(int userId);
        void Update(CreateAndUpdateUserDto dto, int userId);

    }
}
