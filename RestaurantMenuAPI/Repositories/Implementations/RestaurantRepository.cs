using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Models.DTOs;
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

        public bool CheckIfExists(int restId)
        {
            return _context.Restaurants.Any(r => r.Id == restId);
        }

        public int Create(Restaurant newRest)
        {
            Restaurant createdRest = _context.Restaurants.Add(newRest).Entity;
            _context.SaveChanges();
            return createdRest.Id;
        }

        public void Disable(Restaurant rest)
        {
            rest.State = State.Inactive;
            _context.SaveChanges();
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restaurants.Where(r => r.State == State.Active).ToList();
        }

        public Restaurant? GetById(int restId)
        {
            Restaurant? rest = _context.Restaurants.Find(restId);
            if (rest == null || rest.State == State.Inactive)
            {
                return null;
            }
            return rest;
        }

        public void Remove(int restId)
        {
            Restaurant? rest = GetById(restId);
            if (rest == null)
            {
                throw new Exception("El restaurante no existe");
            }
            Disable(rest);
        }

        public void Update(Restaurant updatedRest, int restId)
        {
            Restaurant? rest = GetById(restId);
            if (rest == null)
            {
                throw new Exception("El restaurante no existe");
            }
            rest.Name = updatedRest.Name;
            rest.Description = updatedRest.Description;
            rest.ImageUrl = updatedRest.ImageUrl;
            rest.Number = updatedRest.Number;
            rest.Address = updatedRest.Address;
            rest.OpeningTime = updatedRest.OpeningTime;
            rest.ClosingTime = updatedRest.ClosingTime;
            rest.OpeningDays = updatedRest.OpeningDays;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar el restaurante. No se detectó ningún cambio.");
            }

        }

        public Restaurant? Validate(AuthDto dto)
        {
            return _context.Restaurants.FirstOrDefault(p => p.Email == dto.Email && p.Password == dto.Password);
        }
    }
}
