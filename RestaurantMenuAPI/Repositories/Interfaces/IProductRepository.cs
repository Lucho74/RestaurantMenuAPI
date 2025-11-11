using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        int Create(Product newProduct);
        List<Product> GetAllByRestaurant(int restId);
        List<Product> GetAllByCategory(int categoryId);
        Product? GetById(int productId);
        void Remove(int productId);
        void Update(Product updatedProduct, int productId);
        void AddCategoryToProduct(int productId, int categoryId);
        void ApplyDiscount(Product productWithDiscount, int productId);
        void UpdateOnlyPrice(decimal newPrice, int productId);

    }
}
