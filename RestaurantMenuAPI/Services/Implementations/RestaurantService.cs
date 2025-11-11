using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.Enums;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public bool CheckIfExists(int restId)
        {
            return _restaurantRepository.CheckIfExists(restId);
        }

        public RestaurantDto Create(CreateRestaurantDto dto)
        {
            Restaurant newRest = new Restaurant()
            {
                Email = dto.Email,
                Password = dto.Password,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Number = dto.Number,
                Address = dto.Address,
                OpeningTime = dto.OpeningTime,
                ClosingTime = dto.ClosingTime,
                OpeningDays = dto.OpeningDays,
                State = State.Active
            };
            int newRestId = _restaurantRepository.Create(newRest);
            RestaurantDto createdRest = GetById(newRestId);
            return new RestaurantDto
            (
                createdRest.Id,
                createdRest.Email,
                createdRest.Name,
                createdRest.Description,
                createdRest.ImageUrl,
                createdRest.Number,
                createdRest.Address,
                createdRest.OpeningTime,
                createdRest.ClosingTime,
                createdRest.OpeningDays,
                IsOpen(createdRest.OpeningTime, createdRest.ClosingTime, createdRest.OpeningDays),
                createdRest.State
            );
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            return _restaurantRepository.GetAll().Select(r => new RestaurantDto
            (
                r.Id,
                r.Email,
                r.Name,
                r.Description,
                r.ImageUrl,
                r.Number,
                r.Address,
                r.OpeningTime,
                r.ClosingTime,
                r.OpeningDays,
                IsOpen(r.OpeningTime, r.ClosingTime, r.OpeningDays),
                r.State
            ));
        }

        public RestaurantDto? GetById(int restId)
        {
            Restaurant? rest = _restaurantRepository.GetById(restId);
            if (rest == null)
            {
                return null;
            }
            return new RestaurantDto
            (
                rest.Id,
                rest.Email,
                rest.Name,
                rest.Description,
                rest.ImageUrl,
                rest.Number,
                rest.Address,
                rest.OpeningTime,
                rest.ClosingTime,
                rest.OpeningDays,
                IsOpen(rest.OpeningTime, rest.ClosingTime, rest.OpeningDays),
                rest.State
            );
        }

        public bool IsOpen(TimeSpan openingTime, TimeSpan closingTime, string openingDays)
        {
            var now = DateTime.Now.TimeOfDay;
            var today = (int)DateTime.Now.DayOfWeek;
            var todayAdjusted = today == 0 ? 7 : today; // Domingo = 7

            return openingDays.Contains(todayAdjusted.ToString()) &&
                   now >= openingTime &&
                   now <= closingTime;
        }

        public void Remove(int restId)
        {
            _restaurantRepository.Remove(restId);
        }

        public void Update(UpdateRestaurantDto dto, int restId)
        {
            Restaurant updatedRest = new Restaurant()
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Number = dto.Number,
                Address = dto.Address,
                OpeningTime = dto.OpeningTime,
                ClosingTime = dto.ClosingTime,
                OpeningDays = dto.OpeningDays,
            };
            _restaurantRepository.Update(updatedRest, restId);
        }

        public Restaurant? Validate(AuthDto dto)
        {
            Restaurant? result = null;

            if (!string.IsNullOrEmpty(dto.Email) && !string.IsNullOrEmpty(dto.Password))
                result = _restaurantRepository.Validate(dto);
            return result;
        }

    }
}
