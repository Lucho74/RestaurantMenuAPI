using RestaurantMenuAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public Category Category { get; set; }
        public SpecialCategory SpecialCategory { get; set; }
        public bool IsFeatured { get; set; } = false;
        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu{ get; set; }

    }
}
