using Microsoft.AspNetCore.Mvc;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.ProductService
{
    /// <summary>
    /// Outlines a contract for interacting with the database, and returning data to the client.
    /// </summary>
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductDto>>> GetAllProductsAsync();
        Task<ServiceResponse<ProductDto>> GetProductByIdAsync(Guid productId);
        Task<ServiceResponse<ProductDto>> PostProductAsync(ProductDto productDto, IFormFile imageFile);
        Task<ServiceResponse<ProductDto>> CreateProductAsync(ProductDto productDto);
        Task<ServiceResponse<ProductDto>> UpdateProductByIdAsync(Guid productId, ProductDto productDto);
        Task<ServiceResponse<bool>> DeleteProductByIdAsync(Guid productId);
    }
}
