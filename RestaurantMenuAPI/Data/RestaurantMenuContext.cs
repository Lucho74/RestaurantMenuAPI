using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.Enums;
using System.Data.Common;

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
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).ValueGeneratedOnAdd();

                entity.Property(r => r.Email).IsRequired();
                entity.HasIndex(r => r.Email).IsUnique();

                entity.Property(r => r.Name).IsRequired();
                entity.Property(r => r.PasswordHash).IsRequired();
                entity.Property(r => r.Views).HasDefaultValue(0);

                entity.Property(r => r.OpeningTime).IsRequired();
                entity.Property(r => r.ClosingTime).IsRequired();
                entity.Property(r => r.OpeningDays).IsRequired();

                // Relaciones
                entity.HasMany(r => r.Products)
                      .WithOne(p => p.Restaurant)
                      .HasForeignKey(p => p.RestaurantId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.Categories)
                      .WithOne(c => c.Restaurant)
                      .HasForeignKey(c => c.RestaurantId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.HappyHour)
                      .WithOne(h => h.Restaurant)
                      .HasForeignKey<HappyHour>(h => h.RestaurantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<HappyHour>(entity =>
            {
                entity.HasKey(h => h.RestaurantId);

                entity.Property(h => h.IsActive).HasDefaultValue(true);
                entity.Property(h => h.DiscountPercentage).IsRequired();
                entity.Property(h => h.StartTime).IsRequired();
                entity.Property(h => h.EndTime).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Price).IsRequired();

                entity.Property(p => p.IsFeatured).HasDefaultValue(false);
                entity.Property(p => p.HasDiscount).HasDefaultValue(false);
                entity.Property(p => p.HasHappyHour).HasDefaultValue(false);

                entity.Property(p => p.RestaurantId).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(r => r.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.RestaurantId).IsRequired();
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


            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Email = "restaurant@example.com",
                    PasswordHash = "hashed_password_123",
                    Name = "Mi Restaurante",
                    ImageUrl = "https://example.com/restaurant.jpg",
                    Description = "Un restaurante de comida tradicional",
                    Number = "+1234567890",
                    Address = "Calle Principal 123",
                    Views = 150,
                    OpeningTime = new TimeSpan(9, 0, 0),
                    ClosingTime = new TimeSpan(22, 0, 0),
                    OpeningDays = "1,2,3,4,5,6",
                    State = State.Active
                }
            );

            modelBuilder.Entity<HappyHour>().HasData(
                new HappyHour
                {
                    RestaurantId = 1,
                    IsActive = true,
                    DiscountPercentage = 20,
                    StartTime = new TimeSpan(18, 0, 0),
                    EndTime = new TimeSpan(20, 0, 0)
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Entradas", Description = "Platos de entrada", RestaurantId = 1 },
                new Category { Id = 2, Name = "Platos Fuertes", Description = "Platos principales", RestaurantId = 1 },
                new Category { Id = 3, Name = "Postres", Description = "Deliciosos postres", RestaurantId = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Ceviche",
                    Price = 25.99m,
                    Description = "Ceviche de pescado fresco",
                    ImageUrl = "https://example.com/ceviche.jpg",
                    IsFeatured = true,
                    RestaurantId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Lomo Saltado",
                    Price = 35.50m,
                    Description = "Plato tradicional peruano",
                    ImageUrl = "https://example.com/lomo.jpg",
                    RestaurantId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Suspiro Limeño",
                    Price = 12.75m,
                    Description = "Postre tradicional",
                    ImageUrl = "https://example.com/suspiro.jpg",
                    RestaurantId = 1
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 2 },
                new ProductCategory { ProductId = 3, CategoryId = 3 }
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}
