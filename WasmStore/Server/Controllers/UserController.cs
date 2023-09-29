using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Server.Services;
using WasmStore.Server.Services.AddressService;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        public UserController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpPost("{userId}/addresses")]
        public async Task<ActionResult<ServiceResponse<AddressDto>>> AddAddressToUserAsync(string userId, [FromBody] AddressDto addressDto)
        {
            return await _addressService.AddAddressToUserAsync(userId, addressDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AppUserDto>>> GetUserByIdAsync(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AppUserDto>>>> GetAllUsersAsync()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AppUserDto>>> CreateUserAsync(AppUserDto userDto)
        {
            var newUserResponse = await _userService.CreateUserAsync(userDto);

            if (newUserResponse.Value.Success) // Check if the operation was successful
            {
                var newUser = newUserResponse.Value.Data; // Extract the AppUserDto object
                return CreatedAtAction(nameof(GetUserByIdAsync), new { id = newUser.Id }, newUserResponse.Value);
            }

            return BadRequest(newUserResponse.Value); // Return the error message if the operation failed
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<AppUserDto>>> UpdateUserByIdAsync(string id, AppUserDto userDto)
        {
            var updatedUser = await _userService.UpdateUserByIdAsync(id, userDto);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteUserByIdAsync(string id)
        {
            var resultResponse = await _userService.DeleteUserByIdAsync(id);

            if (resultResponse.Value.Success) // Check if the operation was successful
            {
                return NoContent();
            }

            return NotFound(resultResponse.Value); // Return the error message if the operation failed
        }



    }
}
