using WasmStore.Shared.DTOs;
using AutoMapper;
using WasmStore.Shared.Models;
using WasmStore.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace WasmStore.Server.Services.AddressService
{
        public class AddressService : IAddressService
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public AddressService(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<AddressDto>> UpdateAddressByIdAsync(Guid addressId, AddressDto addressDto)
            {
                var address = await _context.Addresses.FindAsync(addressId);
                if (address == null)
                {
                    return new ServiceResponse<AddressDto> { Success = false, Message = "Address not found." };
                }

                // Update the address properties using AutoMapper
                _mapper.Map(addressDto, address);
                address.DateModified = DateTime.UtcNow;

                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();

                return new ServiceResponse<AddressDto> { Data = _mapper.Map<AddressDto>(address), Message = "Address updated successfully." };
            }
            public async Task<ServiceResponse<AddressDto>> CreateAddressAsync(AddressDto addressDto, string userId)
            {
                var address = _mapper.Map<Address>(addressDto);
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();

                // Create UserAddress entry
                var userAddress = new UserAddress
                {
                    AddressId = address.Id,
                    ApplicationUserId = userId
                };
                await _context.UserAddresses.AddAsync(userAddress);
                await _context.SaveChangesAsync();

                return new ServiceResponse<AddressDto> { Data = _mapper.Map<AddressDto>(address), Message = "Address created successfully." };
            }
            public async Task<ServiceResponse<List<AddressDto>>> GetAllAddressesAsync()
            {
                var addresses = await _context.Addresses.ToListAsync();
                var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
                return new ServiceResponse<List<AddressDto>> { Data = addressDtos, Message = "Addresses fetched successfully." };
            }
            public async Task<ServiceResponse<AddressDto>> GetAddressByIdAsync(Guid addressId)
            {
                var address = await _context.Addresses.FindAsync(addressId);
                if (address == null)
                {
                    return new ServiceResponse<AddressDto> { Success = false, Message = "Address not found." };
                }
                var addressDto = _mapper.Map<AddressDto>(address);
                return new ServiceResponse<AddressDto> { Data = addressDto, Message = "Address fetched successfully." };
            }
            public async Task<ServiceResponse<bool>> DeleteAddressByIdAsync(Guid addressId, bool confirmCascadeDelete = false)
            {
                var response = new ServiceResponse<bool>();
                var address = await _context.Addresses.FindAsync(addressId);

                if (address == null)
                {
                    response.Success = false;
                    response.Message = "Address not found.";
                    return response;
                }

                // Check if the address is associated with any users
                var isAddressAssociated = await _context.UserAddresses.AnyAsync(ua => ua.AddressId == addressId);

                if (isAddressAssociated)
                {
                    if (!confirmCascadeDelete)
                    {
                        response.Success = false;
                        response.Message = "Address is associated with one or more users. Confirm to cascade delete.";
                        return response;
                    }
                    else
                    {
                        // Cascade delete
                        _context.UserAddresses.RemoveRange(_context.UserAddresses.Where(ua => ua.AddressId == addressId));
                    }
                }

                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

                response.Data = true;
                response.Message = "Address successfully deleted.";
                return response;
            }
            public async Task<ActionResult<ServiceResponse<AddressDto>>> AddAddressToUserAsync(string userId, [FromBody] AddressDto addressDto)
            {
            var serviceResponse = new ServiceResponse<AddressDto>();

            // Validate if the user exists
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            // Create the Address
            var address = new Address
            {
                AddressLine = addressDto.AddressLine,
                City = addressDto.City,
                Province = addressDto.Province,
                Country = addressDto.Country,
                PostalCode = addressDto.PostalCode,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            // Create the UserAddress
            var userAddress = new UserAddress
            {
                ApplicationUserId = userId,
                AddressId = address.Id,
                DateCreated = DateTime.UtcNow

            };
          
            await _context.UserAddresses.AddAsync(userAddress);
            await _context.SaveChangesAsync();

            // Populate the DTO to return
            addressDto.Id = address.Id;

            serviceResponse.Data = addressDto;
            serviceResponse.Message = "Address added successfully";

            return serviceResponse;
        }
    }
}
