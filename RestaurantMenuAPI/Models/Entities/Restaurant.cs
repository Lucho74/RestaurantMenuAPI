using RestaurantMenuAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }
        public int Views { get; set; } = 0;
        [Required]
        public TimeSpan OpeningTime { get; set; }
        [Required]
        public TimeSpan ClosingTime { get; set; }
        [Required]
        public string OpeningDays { get; set; }
        public ICollection<Category>? Categories { get; set; } = new List<Category>();
        public ICollection<Product>? Products { get; set; } = new List<Product>();
        public HappyHour? happyHour { get; set; }
        public State State { get; set; } 



    }
}
