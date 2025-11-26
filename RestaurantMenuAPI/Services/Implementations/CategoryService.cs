using Microsoft.CodeAnalysis;
using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Services.Interfaces;

namespace RestaurantMenuAPI.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDto Create(CreateAndUpdateCategoryDto dto, int restId)
        {
            Category newCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
                RestaurantId = restId
            };
            int newCategoryId = _categoryRepository.Create(newCategory);
            return new CategoryDto
            (
                newCategoryId,
                newCategory.Name,
                newCategory.Description,
                newCategory.RestaurantId
            );
        }

        public IEnumerable<CategoryDto> GetAllByProduct(int productId)
        {
            return _categoryRepository.GetAllByProduct(productId).Select(c => new CategoryDto
            (
                c.Id,
                c.Name,
                c.Description,
                c.RestaurantId
            ));
        }

        public IEnumerable<CategoryDto> GetAllByRestaurant(int restId)
        {
            return _categoryRepository.GetAllByRestaurant(restId).Select(c => new CategoryDto
            (
                c.Id,
                c.Name,
                c.Description,
                c.RestaurantId
            ));
        }

        public CategoryWithProductsDto? GetById(int categoryId)
        {
            Category? category = _categoryRepository.GetById(categoryId);
            if (category == null)
            {
                return null;
            }
            return new CategoryWithProductsDto
            (
                category.Id,
                category.Name,
                category.Description,
                category.RestaurantId,
                category.ProductCategories.Select(pc => pc.Product.Id).ToList()
            );
        }

        public void Remove(int categoryId)
        {
            _categoryRepository.Remove(categoryId);
        }

        public void Update(CreateAndUpdateCategoryDto dto, int categoryId)
        {
            Category updatedCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            _categoryRepository.Update(updatedCategory, categoryId);
        }
    }
}
