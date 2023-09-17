using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WasmStore.Server.Models;

namespace WasmStore.Server.Services.SeedService
{ 
    public class SeedService : ISeedService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            var roles = new[] { "User", "Admin" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public async Task SeedDefaultUsersAsync()
        {
            var defaultAdmin = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com" };
            var result = await _userManager.CreateAsync(defaultAdmin, "Admin123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(defaultAdmin, "Admin");
            }

            var defaultUser = new ApplicationUser { UserName = "user@example.com", Email = "user@example.com" };
            result = await _userManager.CreateAsync(defaultUser, "User123!");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(defaultUser, "User");
            }
        }

        public async Task SeedPlaceholderDataAsync()
        {
            //
        }
        // Implement other seed methods as needed
    }

}
