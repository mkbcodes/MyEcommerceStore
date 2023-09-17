using Microsoft.AspNetCore.Mvc;

namespace WasmStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Asynchronous call to get a list of products, basically IActionResult defines a contract that is the result of a request.
        // When the client (in my case, the Blazor WASM app) sends a GET request to the server to ask for products, this method will be executed.The IActionResult is a way for the server to package up its response to the client's HTTP request. and The Ok(Products) part essentially means that the server is responding with a "200 OK" status code along with the data (Products in this example). This is a standard way to say "Hey, everything went well, and here's the data you asked for."
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> CreateProduct(Product product)
        {
            var result = await _productService.PostProductAsync(product);
            return Ok(result);
        }
    }
}
