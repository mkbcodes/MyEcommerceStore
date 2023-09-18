using System.Net.Http.Json;
using WasmStore.Shared;

namespace WasmStore.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; }
        /*public async Task<Product> PostProduct(Product product)
        {
           
        }*/
        public async Task<ServiceResponse<Product>> PostProduct(Product product)
        {
            // Use PostAsJsonAsync to send the product object as JSON in the request body
            var response = await _http.PostAsJsonAsync("api/product", product);

            // Deserialize the response to ServiceResponse<Product>
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>();

                
            if (result != null && result.Data != null)
            {
                Product = result.Data;
            }
            return result;

        }



        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (result != null && result.Data != null)
                Products = result.Data;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }
    }
}
