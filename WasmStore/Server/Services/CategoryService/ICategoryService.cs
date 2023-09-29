using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();
        Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(Guid Id);
        Task<ServiceResponse<CategoryDto>> PostCategoryByIdAsync(CategoryDto categoryDto);
        Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto);
        Task<ServiceResponse<CategoryDto>> UpdateCategoryByIdAsync(Guid categoryId, CategoryDto categoryDto);
        Task<ServiceResponse<bool>> DeleteCategoryByIdAsync(Guid categoryId);

    }
}
