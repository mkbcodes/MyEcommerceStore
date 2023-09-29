using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Server.Services;
using WasmStore.Server.Services.AddressService;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddressDto>>> CreateAddressAsync([FromBody] AddressDto addressDto, string userId)
        {
            var response = await _addressService.CreateAddressAsync(addressDto, userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<AddressDto>>> GetAllAddressesAsync()
        {
            var response = await _addressService.GetAllAddressesAsync();
            return Ok(response);
        }

        [HttpGet("{addressId}")]
        public async Task<ActionResult<ServiceResponse<AddressDto>>> GetAddressByIdAsync(Guid addressId)
        {
            var response = await _addressService.GetAddressByIdAsync(addressId);
            return Ok(response);
        }

        [HttpDelete("{addressId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAddressByIdAsync(Guid addressId, [FromQuery] bool confirmCascadeDelete = false)
        {
            var response = await _addressService.DeleteAddressByIdAsync(addressId, confirmCascadeDelete);
            return Ok(response);
        }
        /*[HttpGet("user/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<AddressDto>>>> GetAllAddressesForUserId(string userId)
        {
            var response = await _addressService.GetAllAddressesForUserId(userId);
            return Ok(response);
        }
*/

        [HttpPut("{addressId}")]
        public async Task<ActionResult<ServiceResponse<AddressDto>>> UpdateAddressByIdAsync(Guid addressId, [FromBody] AddressDto addressDto)
        {
            var response = await _addressService.UpdateAddressByIdAsync(addressId, addressDto);
            return Ok(response);
        }

    }
}
