using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WasmStore.Server.Services.SeedService;
namespace WasmStore.Server.Controllers
{

    [ApiController]
    [Route("admin/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public SeedController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        [HttpPost("roles")]
        public async Task<IActionResult> SeedRoles()
        {
            await _seedService.SeedRolesAsync();
            return Ok("Roles seeded successfully.");
        }

        // Add other endpoints that utilize the seed service as needed
    }

}
