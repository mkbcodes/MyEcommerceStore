using AutoMapper;
using WasmStore.Server.Data;
using WasmStore.Shared.DTOs;
using WasmStore.Server.Services.CartService;
using WasmStore.Shared.Models;
using WasmStore.Server.Models;

namespace WasmStore.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CartDto>> CreateCartForUserAsync(CartDto cartDto, string userId)
        {
            // Check if a cart already exists for the user
            var existingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(c => c.ApplicationUserId == userId);
            if (existingCart != null)
            {
                return new ServiceResponse<CartDto> { Success = false, Message = "Cart already exists for this user." };
            }

            // Create a new cart
            var newCart = new ShoppingCart { ApplicationUserId = userId };
            await _context.ShoppingCarts.AddAsync(newCart);
            await _context.SaveChangesAsync();

            var backTocartDto = _mapper.Map<CartDto>(newCart);
            return new ServiceResponse<CartDto> { Data = backTocartDto, Message = "Cart created successfully." };
        }


        public async Task<ServiceResponse<List<CartDto>>> GetAllCartsAsync()
        {
            var carts = await _context.ShoppingCarts.ToListAsync();
            var cartDtos = _mapper.Map<List<CartDto>>(carts);
            return new ServiceResponse<List<CartDto>> { Data = cartDtos, Message = "Retrieved all carts." };
        }

        public async Task<ServiceResponse<CartDto>> GetCartByIdAsync(Guid cartId)
        {
            var cart = await _context.ShoppingCarts.FindAsync(cartId);
            if (cart == null)
            {
                return new ServiceResponse<CartDto> { Success = false, Message = "Cart not found." };
            }

            var cartDto = _mapper.Map<CartDto>(cart);
            return new ServiceResponse<CartDto> { Data = cartDto, Message = "Cart retrieved successfully." };
        }

        public async Task<ServiceResponse<CartDto>> UpdateCartAsync(Guid cartId, CartDto cartDto)
        {
            var cart = await _context.ShoppingCarts.FindAsync(cartId);
            if (cart == null)
            {
                return new ServiceResponse<CartDto> { Success = false, Message = "Cart not found." };
            }

            _mapper.Map(cartDto, cart);
            _context.ShoppingCarts.Update(cart);
            await _context.SaveChangesAsync();

            return new ServiceResponse<CartDto> { Data = cartDto, Message = "Cart updated successfully." };
        }

        public async Task<ServiceResponse<bool>> DeleteCartByIdAsync(Guid cartId)
        {
            var cart = await _context.ShoppingCarts.FindAsync(cartId);
            if (cart == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Cart not found." };
            }

            _context.ShoppingCarts.Remove(cart);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Cart deleted successfully." };
        }

        public async Task<ServiceResponse<CartDto>> CreateCartForUserAsync(string userId)
        {
            var cart = new ShoppingCart { ApplicationUserId = userId }; // Assuming ApplicationUserId is a string
            await _context.ShoppingCarts.AddAsync(cart);
            await _context.SaveChangesAsync();

            var cartDto = _mapper.Map<CartDto>(cart);
            return new ServiceResponse<CartDto> { Data = cartDto, Message = "Cart created for user successfully." };
        }

        public async Task<ServiceResponse<CartItemDto>> AddItemToCartAsync(Guid cartId, CartItemDto cartItemDto)
        {
            var cart = await _context.ShoppingCarts.FindAsync(cartId);
            if (cart == null)
            {
                return new ServiceResponse<CartItemDto> { Success = false, Message = "Cart not found." };
            }

            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            cart.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            cartItemDto.Id = cartItem.Id;
            return new ServiceResponse<CartItemDto> { Data = cartItemDto, Message = "Item added to cart successfully." };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCartAsync(Guid cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Cart item not found." };
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Item removed from cart successfully." };
        }

    }
}
