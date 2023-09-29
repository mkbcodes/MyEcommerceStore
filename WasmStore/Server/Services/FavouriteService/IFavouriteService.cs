using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.FavouriteService
{ 
    public interface IFavouriteService
    {
        Task<ServiceResponse<List<FavouriteDto>>> GetFavouritesByUserIdAsync(string userId);
        Task<ServiceResponse<List<FavouriteDto>>> GetFavouritesByProductIdAsync(Guid productId);
        Task<ServiceResponse<bool>> IsFavouriteAsync(string userId, Guid productId);
        Task<ServiceResponse<FavouriteDto>> AddToFavouritesAsync(string userId, Guid productId);
        Task<ServiceResponse<bool>> RemoveFromFavouritesAsync(Guid favouriteId);
    }


}
