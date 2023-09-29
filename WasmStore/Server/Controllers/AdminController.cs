using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WasmStore.Server.Models;
using WasmStore.Shared.DTOs;

namespace WasmStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("CreateAdminUser")]
        public async Task<IActionResult> CreateAdminUser([FromBody] AppUserDto model)
        {
            if (ModelState.IsValid)
            {
                // Check if the "Admin" role exists, create if not
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateCreated = model.DateCreated
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Add user to "Admin" role
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return Ok(new { Message = "Admin user created successfully" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest("Invalid model");
        }
    }
}
