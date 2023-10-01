using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Shared.DTOs;
using WasmStore.Server.Services.CartService;

namespace WasmStore.Server.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // POST: api/cart/user/{userId}
        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> CreateCartForUser([FromBody] CartDto cartDto, string userId)
        {
            var response = await _cartService.CreateCartForUserAsync(cartDto, userId);
            return Ok(response);
        }

        // GET: api/cart
        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var response = await _cartService.GetAllCartsAsync();
            return Ok(response);
        }

        // GET: api/cart/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(Guid id)
        {
            var response = await _cartService.GetCartByIdAsync(id);
            return Ok(response);
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(Guid id, [FromBody] CartDto cartDto)
        {
            var response = await _cartService.UpdateCartAsync(id, cartDto);
            return Ok(response);
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartById(Guid id)
        {
            var response = await _cartService.DeleteCartByIdAsync(id);
            return Ok(response);
        }
       

        // POST: api/cart/{cartId}/item
        [HttpPost("{cartId}/item")]
        public async Task<IActionResult> AddItemToCart(Guid cartId, [FromBody] CartItemDto cartItemDto)
        {
            var response = await _cartService.AddItemToCartAsync(cartId, cartItemDto);
            return Ok(response);
        }

        // DELETE: api/cart/item/{cartItemId}
        [HttpDelete("item/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(Guid cartItemId)
        {
            var response = await _cartService.RemoveItemFromCartAsync(cartItemId);
            return Ok(response);
        }
    }
}
