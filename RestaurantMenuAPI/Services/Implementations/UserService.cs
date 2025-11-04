using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Services.Interfaces;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckIfExists(int userId)
        {
            return _userRepository.CheckIfExists(userId);
        }

        public UserDto Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                Email = dto.Email,
                Password = dto.Password,
                State = State.Active
            };
            int newUserId = _userRepository.Create(newUser);
            GetUserByIdDto createdUser = GetById(newUserId);
            return new UserDto(createdUser.Id, createdUser.Email, createdUser.State); 
        }   

        public IEnumerable<UserDto> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UserDto(u.Id, u.Email, u.State));
        }

        public GetUserByIdDto? GetById(int userId)
        {
            User user = _userRepository.GetById(userId);
            if (user == null)
            {
                return null;
            }
            return new GetUserByIdDto(user.Id, user.Email, user.State);
        }

        public void Remove(int userId)
        {
            _userRepository.Remove(userId);
        }

        public void Update(CreateAndUpdateUserDto dto, int userId)
        {
            throw new NotImplementedException();
        }

        public User? Validate(string email, string password)
        {
            return _userRepository.Validate(email, password);
        }
    }
}
