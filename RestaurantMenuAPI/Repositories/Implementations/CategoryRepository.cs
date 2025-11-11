using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;

namespace RestaurantMenuAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestaurantMenuContext _context;
        public CategoryRepository(RestaurantMenuContext context)
        {
            _context = context;
        }

        public int Create(Category newCategory)
        {
            Category createdCategory = _context.Categories.Add(newCategory).Entity;
            _context.SaveChanges();
            return createdCategory.Id;
        }

        public List<Category> GetAllByProduct(int productId)
        {
            return _context.ProductCategories.Where(pc => pc.ProductId == productId)
                .Include(pc => pc.Category)
                .Select(pc => pc.Category)
                .ToList();
        }

        public List<Category> GetAllByRestaurant(int restId)
        {
            return _context.Categories.Where(c => c.RestaurantId == restId).ToList();
        }

        public Category? GetById(int categoryId)
        {
            Category? category = _context.Categories
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public void Remove(int categoryId)
        {
            Category? category = GetById(categoryId);
            if (category == null)
            {
                throw new Exception("La categoría no existe");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }

        public void Update(Category updatedCategory, int categoryId)
        {
            Category? category = GetById(categoryId);
            if (category == null)
            {
                throw new Exception("La categoría no existe");
            }
            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar la categoría. No se detectó ningún cambio.");
            }
        }
    }
}
