using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;

namespace RestaurantMenuAPI.Services.Interfaces
{
    public interface IProductService
    {
        ProductDto Create(CreateAndUpdateProductDto dto, int restId);
        IEnumerable<ProductDto> GetAllByCategory(int categoryId, int restId);
        IEnumerable<ProductDto> GetAllByRestaurant(int restId);
        ProductWithCategoriesDto? GetById(int productId, int restId);
        void Remove(int productId);
        void Update(CreateAndUpdateProductDto dto, int productId);
        void AddCategoryToProduct(int productId, int categoryId);
        void ApplyDiscount(ProductDiscountDto productDiscount, int productId, int restId);
        void IncreaseAllPrices(int restId, int percentage);
        decimal? GetDiscountPrice(Product product);
        bool DiscountExistence(Product product);
    }
}
