using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.TagService
{
    public interface ITagService
    {
        Task<ServiceResponse<List<TagDto>>> GetAllTagsAsync();
        Task<ServiceResponse<TagDto>> GetTagByIdAsync(Guid tagId);
        Task<ServiceResponse<TagDto>> CreateTagAsync(TagDto tag);
        Task<ServiceResponse<TagDto>> UpdateTagByIdAsync(Guid tagId, TagDto tag);
        Task<ServiceResponse<bool>> DeleteTagByIdAsync(Guid tagId, bool confirmCascadeDelete);
    }
}
