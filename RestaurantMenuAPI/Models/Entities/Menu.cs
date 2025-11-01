using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantMenuAPI.Models.Entities
{
    public class Menu
    {

        public int UserId { get; set; }
        public ICollection<Product> Products { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
