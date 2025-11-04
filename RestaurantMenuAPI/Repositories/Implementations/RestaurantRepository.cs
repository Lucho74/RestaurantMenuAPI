using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.Enums;
using RestaurantMenuAPI.Repositories.Interfaces;

namespace RestaurantMenuAPI.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantMenuContext _context;
        public RestaurantRepository(RestaurantMenuContext context)
        {
            _context = context;
        }

        public bool CheckIfExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }


        public int Create(User newUser)
        {
            User createdUser = _context.Users.Add(newUser).Entity;
            _context.SaveChanges();
            return createdUser.Id;
        }

        public void Disable(User user)
        {
            user.State = State.Inactive;
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(u => u.State == State.Active).ToList();
        }

        public User? GetById(int userId)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null || user.State == State.Inactive) {
                return null;
            }
            return user;
        }

        public void Remove(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }
            Disable(user);
        }

        public void Update(User updatedUser, int userId)
        {
            throw new NotImplementedException();
        }

        public User? Validate(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
