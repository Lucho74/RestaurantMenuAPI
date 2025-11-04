using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Category
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}
