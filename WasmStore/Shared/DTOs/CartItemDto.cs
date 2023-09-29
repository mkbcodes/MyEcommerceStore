using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmStore.Shared.DTOs
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public Guid Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
