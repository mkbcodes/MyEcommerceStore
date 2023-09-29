using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;
namespace WasmStore.Server.Services.CartService
{
        public interface ICartService
        {/*
            Task<ServiceResponse<CartDto>> CreateCartAsync(CartDto cartDto);*/
            Task<ServiceResponse<List<CartDto>>> GetAllCartsAsync();
            Task<ServiceResponse<CartDto>> GetCartByIdAsync(Guid cartId);
            Task<ServiceResponse<CartDto>> UpdateCartAsync(Guid cartId, CartDto cartDto);
            Task<ServiceResponse<bool>> DeleteCartByIdAsync(Guid cartId);
            Task<ServiceResponse<CartDto>> CreateCartForUserAsync(string userId);
            Task<ServiceResponse<CartItemDto>> AddItemToCartAsync(Guid cartId, CartItemDto cartItemDto);
            Task<ServiceResponse<bool>> RemoveItemFromCartAsync(Guid cartItemId);
    
    }

}
