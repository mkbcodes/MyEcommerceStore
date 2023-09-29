using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WasmStore.Shared.DTOs;

namespace WasmStore.Server.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}
