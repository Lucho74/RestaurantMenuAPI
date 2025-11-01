using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Profile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Description { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }
        public Menu? Menu { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
