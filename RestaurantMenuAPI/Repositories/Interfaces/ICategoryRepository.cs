using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        int Create(Category newCategory);
        List<Category> GetAllByRestaurant(int restId);
        List<Category> GetAllByProduct(int productId);
        Category? GetById(int categoryId);
        void Remove(int categoryId);
        void Update(Category updatedCategory, int categoryId);



    }
}
