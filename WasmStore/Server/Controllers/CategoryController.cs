﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Server.Models;
using WasmStore.Server.Services.CategoryService;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPut("{categoryId}")]
        public async Task<ActionResult<ServiceResponse<CategoryDto>>> UpdateCategoryByIdAsync(Guid categoryId, [FromBody] CategoryDto categoryToUpdate)
        {
            var response = await _categoryService.UpdateCategoryByIdAsync(categoryId, categoryToUpdate);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetAllCategoriesAsync()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoryByIdAsync(Guid categoryId)
        {
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);
            return Ok(result);
        }
    }
}
