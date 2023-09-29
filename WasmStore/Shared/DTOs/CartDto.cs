using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmStore.Shared.DTOs
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
}
