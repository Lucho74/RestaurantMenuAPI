using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Menu
    {
        [Key]
        public int ProfileId { get; set; }
        public ICollection<Product>? Products { get; set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
    }
}
