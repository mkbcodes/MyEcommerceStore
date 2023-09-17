namespace WasmStore.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not found.";
            }
            else
            {
                response.Data = product;

            }
            return response;
        }

        public async Task<ServiceResponse<Product>> PostProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();
            
            await _context.AddAsync(product);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                response.Success = false;
                response.Message = "Failed to add product.";
            }
            else
            {
                response.Data = product;
                
            }
            return response;
           
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.ToListAsync()
            };
            return response;
        }
    }
}
