using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WasmStore.Server.Services.FavouriteService;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

[ApiController]
[Route("api/favourites")]
public class FavouritesController : ControllerBase
{
    private readonly IFavouriteService _favouriteService;

    public FavouritesController(IFavouriteService favouriteService)
    {
        _favouriteService = favouriteService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<ServiceResponse<List<FavouriteDto>>>> GetFavouritesByUserId(string userId)
    {
        return Ok(await _favouriteService.GetFavouritesByUserIdAsync(userId));
    }

    [HttpGet("product/{productId}")]
    public async Task<ActionResult<ServiceResponse<List<FavouriteDto>>>> GetFavouritesByProductId(Guid productId)
    {
        return Ok(await _favouriteService.GetFavouritesByProductIdAsync(productId));
    }

    [HttpGet("user/{userId}/product/{productId}")]
    public async Task<ActionResult<ServiceResponse<FavouriteDto>>> IsFavourite(string userId, Guid productId)
    {
        return Ok(await _favouriteService.IsFavouriteAsync(userId, productId));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<FavouriteDto>>> AddToFavourites(FavouriteDto favouriteDto)
    {
        return Ok(await _favouriteService.AddToFavouritesAsync(favouriteDto.ApplicationUserId, favouriteDto.ProductId));
    }

    [HttpDelete("{favouriteId}")]
    public async Task<ActionResult<ServiceResponse<FavouriteDto>>> RemoveFromFavourites(Guid favouriteId)
    {
        return Ok(await _favouriteService.RemoveFromFavouritesAsync(favouriteId));
    }
}
