using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services
{
    public interface IUserService
    {
        Task<ActionResult<ServiceResponse<AppUserDto>>> GetUserByIdAsync(string id);
        Task<ActionResult<ServiceResponse<AppUserDto>>> CreateUserAsync(AppUserDto userDto);
        Task<ActionResult<ServiceResponse<AppUserDto>>> UpdateUserByIdAsync(string id, AppUserDto userDto);
        Task<ActionResult<ServiceResponse<bool>>> DeleteUserByIdAsync(string id);
        Task<ServiceResponse<List<AppUserDto>>> GetAllUsersAsync();
    }
}
