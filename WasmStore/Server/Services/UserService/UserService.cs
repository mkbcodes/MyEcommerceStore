using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WasmStore.Server.Models;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ActionResult<ServiceResponse<AppUserDto>>> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ServiceResponse<AppUserDto>
                {
                    Message = "User not found",
                    Success = false
                };
            }

            return new ServiceResponse<AppUserDto>
            {
                Data = new AppUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    DateCreated = user.DateCreated
                },
                Message = "User retrieved successfully",
                Success = true
            };
        }

        public async Task<ActionResult<ServiceResponse<AppUserDto>>> CreateUserAsync(AppUserDto userDto)
        {
            var user = new ApplicationUser
            {   
                Id = userDto.Id,
                UserName = userDto.Email,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateCreated = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                return new ServiceResponse<AppUserDto>
                {
                    Message = "User creation failed",
                    Success = false
                };
            }

            return new ServiceResponse<AppUserDto>
            {
                Data = userDto,
                Message = "User created successfully",
                Success = true
            };
        }

        public async Task<ActionResult<ServiceResponse<AppUserDto>>> UpdateUserByIdAsync(string id, AppUserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ServiceResponse<AppUserDto>
                {
                    Message = "User not found",
                    Success = false
                };
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ServiceResponse<AppUserDto>
                {
                    Message = "User update failed",
                    Success = false
                };
            }

            return new ServiceResponse<AppUserDto>
            {
                Data = userDto,
                Message = "User updated successfully",
                Success = true
            };
        }
        public async Task<ServiceResponse<List<AppUserDto>>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = _mapper.Map<List<AppUserDto>>(users);

            return new ServiceResponse<List<AppUserDto>>
            {
                Data = userDtos,
                Message = "Retrieved all users",
                Success = true
            };
        }

        public async Task<ActionResult<ServiceResponse<bool>>> DeleteUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Message = "User not found",
                    Success = false
                };
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return new ServiceResponse<bool>
                {
                    Message = "User deletion failed",
                    Success = false
                };
            }

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "User deleted successfully",
                Success = true
            };
        }
    }
}
