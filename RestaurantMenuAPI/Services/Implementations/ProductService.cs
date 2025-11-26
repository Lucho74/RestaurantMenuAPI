using RestaurantMenuAPI.Models.DTOs;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantMenuAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IHappyHourService _happyHourService;
        public ProductService(IProductRepository productRepository, IHappyHourService happyHourService)
        {
            _productRepository = productRepository;
            _happyHourService = happyHourService;
        }

        public void AddCategoryToProduct(int productId, int categoryId)
        {
            _productRepository.AddCategoryToProduct(productId, categoryId);
        }

        public void ApplyDiscount(ProductDiscountDto productDiscount, int productId)
        {
            Product? existing = _productRepository.GetById(productId);
            if (existing == null)
            {
                throw new Exception("El producto no existe");
            }
            Product productWithDiscount = new Product()
            {
                HasDiscount = productDiscount.HasDiscount,
                DiscountPercentage = productDiscount.DiscountPercentage,
                DiscountStart = productDiscount.DiscountStart,
                DiscountEnd = productDiscount.DiscountEnd
            };
            _productRepository.ApplyDiscount(productWithDiscount, productId);
        }

        public ProductDto Create(CreateAndUpdateProductDto dto, int restId)
        {
            Product newProduct = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                IsFeatured = dto.IsFeatured,
                HasHappyHour = dto.HasHappyHour,
                RestaurantId = restId,
            };
            int newProductId = _productRepository.Create(newProduct);
            ProductWithCategoriesDto? createdProduct = GetById(newProductId);
            if (createdProduct != null)
            {
                return new ProductDto
                (
                    createdProduct.Id,
                    createdProduct.Name,
                    createdProduct.Price,
                    createdProduct.Description,
                    createdProduct.ImageUrl,
                    createdProduct.IsFeatured,
                    createdProduct.HasDiscount,
                    createdProduct.DiscountPercentage,
                    createdProduct.DiscountPrice,
                    createdProduct.DiscountStart,
                    createdProduct.DiscountEnd,
                    createdProduct.HasHappyHour,
                    createdProduct.HappyHourPrice,
                    createdProduct.RestaurantId
                );
            }
            return new ProductDto
            (
                newProductId,
                newProduct.Name,
                newProduct.Price,
                newProduct.Description,
                newProduct.ImageUrl,
                newProduct.IsFeatured,
                newProduct.HasDiscount,
                newProduct.DiscountPercentage,
                GetDiscountPrice(newProduct),
                newProduct.DiscountStart,
                newProduct.DiscountEnd,
                newProduct.HasHappyHour,
                _happyHourService.GetHappyHourPrice(newProduct, restId),
                newProduct.RestaurantId
            );
        }


        public void DeleteCategoryFromProduct(int productId, int categoryId)
        {
            _productRepository.DeleteCategoryFromProduct(productId, categoryId);
        }

        public bool DiscountExistence(Product product)
        {
            DateTime now = DateTime.Now;
            if (product.HasDiscount)
            {
                if (product.DiscountEnd < now)
                {
                    ApplyDiscount(new ProductDiscountDto
                    (
                        !product.HasDiscount,
                        null,
                        null,
                        null
                    ), product.Id);
                    return false;
                }
                return true;
            }
            else return false;
        }

        public IEnumerable<ProductDto> GetAllByCategory(int categoryId, int restId)
        {
            return _productRepository.GetAllByCategory(categoryId).Select(p => new ProductDto
            (
                p.Id,
                p.Name,
                p.Price,
                p.Description,
                p.ImageUrl,
                p.IsFeatured,
                DiscountExistence(p),
                p.DiscountPercentage,
                GetDiscountPrice(p),
                p.DiscountStart,
                p.DiscountEnd,
                p.HasHappyHour,
                _happyHourService.GetHappyHourPrice(p, restId),
                p.RestaurantId
            ));
        }

        public IEnumerable<ProductDto> GetAllByRestaurant(int restId)
        {
            return _productRepository.GetAllByRestaurant(restId).Select(p => new ProductDto
            (
                p.Id,
                p.Name,
                p.Price,
                p.Description,
                p.ImageUrl,
                p.IsFeatured,
                DiscountExistence(p),
                p.DiscountPercentage,
                GetDiscountPrice(p),
                p.DiscountStart,
                p.DiscountEnd,
                p.HasHappyHour,
                _happyHourService.GetHappyHourPrice(p, restId),
                p.RestaurantId
            ));
        }

        public ProductWithCategoriesDto? GetById(int productId)
        {
            Product? product = _productRepository.GetById(productId);
            if (product == null)
            {
                return null;
            }
            return new ProductWithCategoriesDto
            (
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.ImageUrl,
                product.IsFeatured,
                DiscountExistence(product),
                product.DiscountPercentage,
                GetDiscountPrice(product),
                product.DiscountStart,
                product.DiscountEnd,
                product.HasHappyHour,
                _happyHourService.GetHappyHourPrice(product, product.RestaurantId),
                product.RestaurantId,
                product.ProductCategories.Select(pc => pc.Category.Id).ToList()
            );
        }

        public decimal? GetDiscountPrice(Product product)
        {
            if (product.HasDiscount)
            {
                return Math.Round((decimal)(product.Price * (1 - product.DiscountPercentage / 100m)), 0);
            }
            else return null;
        }

        public void IncreaseAllPrices(int restId, int percentage)
        {
            _productRepository.GetAllByRestaurant(restId).ForEach(p =>
            {
                p.Price = Math.Round(p.Price * (1 - percentage / 100m), 0);
                _productRepository.UpdateOnlyPrice(p.Price, p.Id);
            });
        }

        public void Remove(int productId)
        {
            _productRepository.Remove(productId);
        }

        public void Update(CreateAndUpdateProductDto dto, int productId)
        {
            Product updatedProduct = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                IsFeatured = dto.IsFeatured,
                HasHappyHour = dto.HasHappyHour,
            };
            _productRepository.Update(updatedProduct, productId);
        }
    }
}
