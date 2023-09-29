using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<AddressDto>> CreateAddressAsync(AddressDto addressDto, string userId);
        Task<ServiceResponse<List<AddressDto>>> GetAllAddressesAsync();
        Task<ServiceResponse<AddressDto>> GetAddressByIdAsync(Guid addressId);
        Task<ServiceResponse<AddressDto>> UpdateAddressByIdAsync(Guid addressId, AddressDto addressDto);
        Task<ServiceResponse<bool>> DeleteAddressByIdAsync(Guid addressId, bool confirmCascadeDelete = false);
        Task<ActionResult<ServiceResponse<AddressDto>>> AddAddressToUserAsync(string userId, AddressDto addressDto);
    }
}
