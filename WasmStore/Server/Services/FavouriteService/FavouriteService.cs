using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WasmStore.Shared.DTOs;
using WasmStore.Server.Models;
namespace WasmStore.Server.Services.FavouriteService
{

    public class FavouriteService : IFavouriteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FavouriteService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<FavouriteDto>>> GetFavouritesByUserIdAsync(string userId)
        {
            var favourites = await _context.Favourites
                .Where(f => f.ApplicationUserId == userId)
                .ToListAsync();

            var dtoList = _mapper.Map<List<FavouriteDto>>(favourites);
            return new ServiceResponse<List<FavouriteDto>> { Data = dtoList, Message = "Fetched successfully" };
        }

        public async Task<ServiceResponse<List<FavouriteDto>>> GetFavouritesByProductIdAsync(Guid productId)
        {
            var favourites = await _context.Favourites
                .Where(f => f.ProductId == productId)
                .ToListAsync();

            var dtoList = _mapper.Map<List<FavouriteDto>>(favourites);
            return new ServiceResponse<List<FavouriteDto>> { Data = dtoList, Message = "Fetched successfully" };
        }

        public async Task<ServiceResponse<bool>> IsFavouriteAsync(string userId, Guid productId)
        {
            var isFavourite = await _context.Favourites
                .AnyAsync(f => f.ApplicationUserId == userId && f.ProductId == productId);

            return new ServiceResponse<bool> { Data = isFavourite, Message = "Checked successfully" };
        }

        public async Task<ServiceResponse<FavouriteDto>> AddToFavouritesAsync(string userId, Guid productId)
        {
            var favourite = new Favourite
            {
                ApplicationUserId = userId,
                ProductId = productId,
                DateCreated = DateTime.UtcNow
            };

            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<FavouriteDto>(favourite);
            return new ServiceResponse<FavouriteDto> { Data = dto, Message = "Added successfully" };
        }

        public async Task<ServiceResponse<bool>> RemoveFromFavouritesAsync(Guid favouriteId)
        {
            var favourite = await _context.Favourites.FindAsync(favouriteId);
            if (favourite == null)
            {
                return new ServiceResponse<bool> { Data = false, Message = "Favourite not found" };
            }

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Removed successfully" };
        }
    }


}
