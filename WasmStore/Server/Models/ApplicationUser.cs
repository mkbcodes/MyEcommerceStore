using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation properties for relationships
        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
