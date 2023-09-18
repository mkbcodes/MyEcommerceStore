using AutoMapper;

namespace WasmStore.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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

        public async Task<ServiceResponse<ProductDTO>> PostProductAsync(ProductDTO productDto)
        {
            // Map the product to a DTO
            var product = _mapper.Map<Product>(productDto);
            var response = new ServiceResponse<ProductDTO>();
          
            await _context.AddAsync(product);

            // Save the product
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                response.Success = false;
                response.Message = "Failed to add product.";
            }
            else
            {
                // if successful Map the Product back to a ProductDTO
                var productDtoOut = _mapper.Map<ProductDTO>(product);
                response.Data = productDtoOut;
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
