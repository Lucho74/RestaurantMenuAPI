using Microsoft.EntityFrameworkCore;
using RestaurantMenuAPI.Models.Entities;
using RestaurantMenuAPI.Models.Enums;

namespace RestaurantMenuAPI.Data
{
    public class RestaurantMenuContext : DbContext
    {   
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public RestaurantMenuContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User restaurantUser = new User()
            {   
                Id = 1,
                Email = "luismiguel@gmail.com",
                Password = "lamismadesiempre",
                State = State.Active,
            };
            Profile restaurantProfile = new Profile()
            {   
                UserId = 1,
                Name = "PrimerRestaurante",
            };
            Menu restaurantMenu = new Menu()
            {
                ProfileId = 1,
            };
            Product restaurantProduct = new Product()
            {
                Id = 1,
                MenuId = 1,
                Name = "PrimerProducto",
                Price = 100,
                Category = Category.PlatosPrincipales,
            };

            modelBuilder.Entity<User>().HasData(restaurantUser);
            modelBuilder.Entity<Profile>().HasData(restaurantProfile);
            modelBuilder.Entity<Menu>().HasData(restaurantMenu);
            modelBuilder.Entity<Product>().HasData(restaurantProduct);


            base.OnModelCreating(modelBuilder);
        }

    }
}
