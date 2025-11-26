using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;

namespace RestaurantMenuAPI.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestaurantMenuContext _context;
        public ProductRepository(RestaurantMenuContext context)
        {
            _context = context;
        }

        public void AddCategoryToProduct(int productId, int categoryId)
        {
            _context.ProductCategories.Add(new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            });
            _context.SaveChanges();
        }

        public void ApplyDiscount(Product productWithDiscount, int productId)
        {
            Product? product = GetById(productId);
            if (product == null)
            {
                throw new Exception("El producto no existe");
            }
            product.HasDiscount = productWithDiscount.HasDiscount;
            product.DiscountPercentage = productWithDiscount.DiscountPercentage;
            product.DiscountStart = productWithDiscount.DiscountStart;
            product.DiscountEnd = productWithDiscount.DiscountEnd;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar el producto. No se detectó ningún cambio.");
            }
        }

        public int Create(Product newProduct)
        {
            Product createdProduct = _context.Products.Add(newProduct).Entity;
            _context.SaveChanges();
            return createdProduct.Id;

        }

        public void DeleteCategoryFromProduct(int productId, int categoryId)
        {
            _context.ProductCategories.Remove(new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            });
            _context.SaveChanges();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _context.ProductCategories.Where(pc => pc.CategoryId == categoryId)
                .Include(pc => pc.Product)
                .Select(pc => pc.Product)
                .ToList();
        }

        public List<Product> GetAllByRestaurant(int restId)
        {
            return _context.Products.Where(p => p.RestaurantId == restId).ToList();
        }

        public Product? GetById(int productId)
        {
            Product? product = _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public void Remove(int productId)
        {
            Product? product = GetById(productId);
            if (product == null)
            {
                throw new Exception("El producto no existe");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product updatedProduct, int productId)
        {
            Product? product = GetById(productId);
            if (product == null)
            {
                throw new Exception("El producto no existe");
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            product.ImageUrl = updatedProduct.ImageUrl;
            product.IsFeatured = updatedProduct.IsFeatured;
            product.HasHappyHour = updatedProduct.HasHappyHour;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar el producto. No se detectó ningún cambio.");
            }
        }

        public void UpdateOnlyPrice(decimal newPrice, int productId)
        {
            Product? product = GetById(productId);
            if (product == null)
            {
                throw new Exception("El producto no existe");
            }
            product.Price = newPrice;
            int modifiedCount = _context.SaveChanges();
            if (modifiedCount == 0)
            {
                throw new Exception("No se pudo actualizar el precio un producto. No se detectó ningún cambio.");
            }
        }
    }
}
