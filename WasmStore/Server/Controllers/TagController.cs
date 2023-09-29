using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Server.Models;
using WasmStore.Server.Services.TagService;
using WasmStore.Shared.DTOs;

namespace WasmStore.Server.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagAsync(TagDto tag)
        {
            var response = await _tagService.CreateTagAsync(tag);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTagsAsync()
        {
            var response = await _tagService.GetAllTagsAsync();
            return Ok(response);
        }

        [HttpGet("{tagId}")]
        public async Task<IActionResult> GetTagByIdAsync(Guid tagId)
        {
            var response = await _tagService.GetTagByIdAsync(tagId);
            return Ok(response);
        }

        [HttpPut("{tagId}")]
        public async Task<IActionResult> UpdateTagByIdAsync(Guid tagId, TagDto tag)
        {
            var response = await _tagService.UpdateTagByIdAsync(tagId, tag);
            return Ok(response);
        }

        [HttpDelete("{tagId}")]
        public async Task<IActionResult> DeleteTagByIdAsync(Guid tagId, bool confirmCascadeDelete)
        {
            var response = await _tagService.DeleteTagByIdAsync(tagId, confirmCascadeDelete);
            return Ok(response);
        }
    }
}
