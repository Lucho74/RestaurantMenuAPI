using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        CategoryDto Create(CreateAndUpdateCategoryDto dto, int restId);
        IEnumerable<CategoryDto> GetAllByRestaurant(int restId);
        IEnumerable<CategoryDto> GetAllByProduct(int productId);
        CategoryWithProductsDto? GetById(int categoryId);
        void Remove(int categoryId);
        void Update(CreateAndUpdateCategoryDto dto, int categoryId);
    }
}
