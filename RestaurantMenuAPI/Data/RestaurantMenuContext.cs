using Microsoft.EntityFrameworkCore;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Data
{
    public class RestaurantMenuContext : DbContext
    {   
        public RestaurantMenuContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<HappyHour> HappyHours { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasIndex(r => r.Email).IsUnique();
            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.CategoryId });

                entity.HasOne(pc => pc.Product)
                      .WithMany(p => p.ProductCategories)
                      .HasForeignKey(pc => pc.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pc => pc.Category)
                      .WithMany(c => c.ProductCategories)
                      .HasForeignKey(pc => pc.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);

            });
            Restaurant restaurant = new Restaurant()
            {   
                Id = 1,
                Email = "a@mail.com",
                Password = "a",
                Name = "PrimerRestaurante",
                OpeningTime = TimeSpan.Parse("8:00:00"),
                ClosingTime = TimeSpan.Parse("00:00:00"),
                OpeningDays = "1,2,3,4,5,6",
                State = State.Active,
            };
            HappyHour happyHour = new HappyHour()
            {
                RestaurantId = 1,
                IsActive = true,
                DiscountPercentage = 50,
                StartTime = TimeSpan.Parse("18:00:00"),
                EndTime = TimeSpan.Parse("20:00:00")

            };
            Category category1= new Category()
            {    
                Id = 1,
                Name = "Hamburguesas",
                RestaurantId = 1,
            };
            Category category2= new Category()
            {
                Id = 2,
                Name = "Pizzas",
                RestaurantId = 1,
            };
            ProductCategory productCategory1 = new ProductCategory()
            {
                CategoryId = 1,
                ProductId = 1,
            };
            ProductCategory productCategory2 = new ProductCategory()
            {
                CategoryId = 1,
                ProductId = 2,
            };
            ProductCategory productCategory3 = new ProductCategory()
            {
                CategoryId = 2,
                ProductId = 3,
            };
            ProductCategory productCategory4 = new ProductCategory()
            {
                CategoryId = 2,
                ProductId = 4,
            };
            Product product1 = new Product()
            {
                Id = 1,
                Name = "Hamburguesa Simple",
                Price = 1000,
                RestaurantId = 1
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "Hamburguesa Doble",
                Price = 2000,
                RestaurantId = 1
            };
            Product product3 = new Product()
            {
                Id = 3,
                Name = "Mozzarella",
                Price = 1500,
                RestaurantId = 1
            };
            Product product4 = new Product()
            {
                Id = 4,
                Name = "Especial",
                Price = 2500,
                RestaurantId = 1
            };


            modelBuilder.Entity<Restaurant>().HasData(restaurant);
            modelBuilder.Entity<Category>().HasData(category1, category2);
            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);
            modelBuilder.Entity<ProductCategory>().HasData(productCategory1, productCategory2, productCategory3, productCategory4);
            modelBuilder.Entity<HappyHour>().HasData(happyHour);


            base.OnModelCreating(modelBuilder);
        }

    }
}
