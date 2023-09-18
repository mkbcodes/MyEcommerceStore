namespace WasmStore.Shared
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public byte[]? Image { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
    }

}
