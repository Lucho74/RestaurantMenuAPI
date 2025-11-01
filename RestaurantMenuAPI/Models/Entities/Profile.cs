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
        public string? Imagen { get; set; }
        public string? Description { get; set; }
        public string? Number { get; set; }
        public string? Adress { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
