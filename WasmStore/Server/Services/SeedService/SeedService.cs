using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WasmStore.Server.Models;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.SeedService
{ 
    public class SeedService : ISeedService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SeedService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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

        public async Task SeedPlaceholderProductDataAsync()
        {
            
            // Create placeholder products
            var products = new[]
            {
                new Product
                {
                    Name = "Woven Wall Hanging",
                    Description = "Elevate your living space with our ethereal Woven Wall Hanging in Macrame! Meticulously handcrafted by skilled artisans, this wall hanging is the epitome of bohemian elegance. Featuring intricate patterns and soft, earthy hues, our macrame wall hanging effortlessly adds texture and charm to any room. Made from 100% premium cotton, it's not just an art piece but a testament to craftsmanship and sustainability.",
                    Price = 9.99m,
                    StockQuantity = 10
                },
                new Product
                {
                    
                    Name = "Vegetable Garden Marker",
                    Description = "Never confuse your basil with your parsley again with our delightful Vegetable Garden Markers! These charming ornaments are designed to bring both flair and functionality to your vegetable garden. Each marker features a beautifully crafted, weather-resistant design that not only labels your plants but also adds a whimsical touch to your garden.",
                    Price = 9.99m,
                    StockQuantity = 10
                },
                new Product
                {
                    
                    Name = "Wall Accent",
                    Description = "Add a dash of romance and elegance to your special day with our Wedding Wall Accent in Embroidery and Decorative elements. This exquisite wall art piece is a perfect backdrop for wedding photos or a focal point in the wedding venue. Created with intricate embroidery work and delicate decorative embellishments, this wall accent captures the essence of love and union in its design.",
                    Price = 9.99m,
                    StockQuantity = 10
                }
            };
            

            // Add products to DbContext
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
        }
        // Implement other seed methods as needed
    }

}
