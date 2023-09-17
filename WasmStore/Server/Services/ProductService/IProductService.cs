using WasmStore.Shared;

namespace WasmStore.Server.Services.ProductService
{
    /// <summary>
    /// Outlines a contract for interacting with the database, and returning data to the client.
    /// </summary>
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<Product>> PostProductAsync(Product product);
    }
}
