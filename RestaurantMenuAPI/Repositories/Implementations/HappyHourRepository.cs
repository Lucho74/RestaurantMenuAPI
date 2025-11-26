using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;

namespace RestaurantMenuAPI.Repositories.Implementations
{
    public class HappyHourRepository : IHappyHourRepository
    {
        private readonly RestaurantMenuContext _context;
        public HappyHourRepository(RestaurantMenuContext context)
        {
            _context = context;
        }

        public int AddConfig(HappyHour newHappyHourConfig)
        {
            HappyHour happyHourConfigCreated = _context.HappyHours.Add(newHappyHourConfig).Entity;
            _context.SaveChanges();
            return happyHourConfigCreated.RestaurantId;
        }

        public void EditConfig(HappyHour editHappyHourConfig, int restId)
        {
            HappyHour happyHour = GetByRestaurantId(restId);
            if (happyHour == null)
            {
                throw new Exception("La HappyHour no configurada o no existe.");
            }
            happyHour.DiscountPercentage = editHappyHourConfig.DiscountPercentage;
            happyHour.IsActive = editHappyHourConfig.IsActive;
            happyHour.StartTime = editHappyHourConfig.StartTime;
            happyHour.EndTime = editHappyHourConfig.EndTime;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar la configuración. No se detectó ningún cambio.");
            }
        }

        public List<HappyHour> GetAll()
        {
            return _context.HappyHours.Where(hh => hh.IsActive == true).ToList();
        }

        public HappyHour? GetByRestaurantId(int restId)
        {
            HappyHour? happyHour = _context.HappyHours.FirstOrDefault(hh => hh.RestaurantId == restId);
            if (happyHour == null)
            {
                return null;
            }
            return happyHour;
        }

        public void Remove(int restId)
        {
            HappyHour? happyHour = GetByRestaurantId(restId);
            if (happyHour == null)
            {
                throw new Exception("El HappyHour no existe");
            }
            _context.HappyHours.Remove(happyHour);
            _context.SaveChanges();
        }

        public void SetActive(int restId)
        {
            HappyHour? happyHour = GetByRestaurantId(restId);
            if (happyHour == null)
            {
                throw new Exception("La HappyHour no configurada o no existe.");
            }
            happyHour.IsActive = !happyHour.IsActive;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo desactivar la HappyHour. No se detectó ningún cambio.");
            }
        }

    }

}
