using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Menu
    {
        [Key]
        public int UserId { get; set; }
        public ICollection<Product>? Products { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
