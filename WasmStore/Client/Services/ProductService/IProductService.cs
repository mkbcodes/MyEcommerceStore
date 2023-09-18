using WasmStore.Shared;

namespace WasmStore.Client.Services.ProductService
{
    /// <summary>
    /// Responsible for interacting with the user interface, managing client-side state, and making HTTP calls to the server.
    /// </summary>
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Product Product { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task<ServiceResponse<Product>> PostProduct(Product product);
    }
}
