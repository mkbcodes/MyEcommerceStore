using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WasmStore.Server.Models;
using WasmStore.Server.Services.SeedService;
using WasmStore.Shared.DTOs;
namespace WasmStore.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public SeedController(ISeedService seedService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _seedService = seedService;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost("roles")]
        public async Task<IActionResult> SeedRoles()
        {
            await _seedService.SeedRolesAsync();
            return Ok("Roles seeded successfully.");
        }
        

    }
    // Add other endpoints that utilize the seed service as needed
}


