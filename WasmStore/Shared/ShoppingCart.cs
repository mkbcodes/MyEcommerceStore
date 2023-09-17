using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmStore.Shared
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}
