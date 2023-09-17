using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmStore.Shared
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? ShoppingCartId { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart? ShoppingCart { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
    }
}
