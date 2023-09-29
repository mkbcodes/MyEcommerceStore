
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryDto> Categories { get; set; }
        Task GetAllCategoriesAsync();
        Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(Guid productId);
    }
}
