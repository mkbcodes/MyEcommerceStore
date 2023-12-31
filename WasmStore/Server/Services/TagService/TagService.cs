﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WasmStore.Server.Models;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TagService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<TagDto>> CreateTagAsync(TagDto tagDto)
        {
            var response = new ServiceResponse<TagDto>();

            try
            {
                // Map the DTO to a Tag entity
                var tag = _mapper.Map<Tag>(tagDto);

                // Add the new tag to the database
                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                // Map the Tag entity back to a TagDto
                var createdTagDto = _mapper.Map<TagDto>(tag);

                response.Data = createdTagDto;
                response.Message = "Tag successfully created.";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}";
                response.Success = false;
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> DeleteTagByIdAsync(Guid tagId, bool confirmCascadeDelete = false)
        {
            var response = new ServiceResponse<bool>();
            var tag = await _context.Tags.FindAsync(tagId);

            if (tag == null)
            {
                response.Success = false;
                response.Message = "Tag not found.";
                return response;
            }

            // Check if the tag is associated with any products
            var isTagAssociated = await _context.ProductTags.AnyAsync(pt => pt.TagId == tagId);

            if (isTagAssociated)
            {
                if (!confirmCascadeDelete)
                {
                    // Option 1: Disallow the deletion
                    response.Success = false;
                    response.Message = "Tag is associated with one or more products. Confirm to delete.";
                    return response;
                }
                else
                {
                    // Option 2: Cascade delete (Only with user confirmation)
                    _context.ProductTags.RemoveRange(_context.ProductTags.Where(pt => pt.TagId == tagId));
                }
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            response.Data = true;
            response.Message = "Tag successfully deleted.";
            return response;
        }
        public async Task<ServiceResponse<List<TagDto>>> GetAllTagsAsync()
        {
            var response = new ServiceResponse<List<TagDto>>();
            try
            {
                var tags = await _context.Tags.ToListAsync();

                if (tags == null || !tags.Any())
                {
                    response.Success = false;
                    response.Message = "No tags found.";
                }
                else
                {
                    response.Data = _mapper.Map<List<TagDto>>(tags);
                    response.Message = "Tags retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<TagDto>> GetTagByIdAsync(Guid tagId)
        {
            var response = new ServiceResponse<TagDto>();
            var tag = await _context.Tags.FirstOrDefaultAsync(e => e.Id == tagId);

            if (tag == null)
            {
                response.Success = false;
                response.Message = "Tag not found.";
            }
            else
            {
                response.Data = _mapper.Map<TagDto>(tag);
            }
            return response;
        }
        public async Task<ServiceResponse<TagDto>> UpdateTagByIdAsync(Guid tagId, [FromBody] TagDto tag)
        {
            var serviceResponse = new ServiceResponse<TagDto>();

            try
            {
                // Fetch the existing tag from the database
                var existingTag = await _context.Tags.FindAsync(tagId);

                if (existingTag == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Tag not found.";
                    return serviceResponse;
                }

                // Update the existing tag with the new values
                existingTag.Name = tag.Name;
                existingTag.Description = tag.Description;
                // Add any other fields you want to update

                _context.Tags.Update(existingTag);
                await _context.SaveChangesAsync();

                // Map the updated tag entity to TagDto
                serviceResponse.Data = new TagDto
                {
                    Id = existingTag.Id,
                    Name = existingTag.Name,
                    Description = existingTag.Description
                    // Add any other fields you want to return
                };

                serviceResponse.Message = "Tag updated successfully.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
