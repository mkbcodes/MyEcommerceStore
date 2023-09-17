using System.ComponentModel.DataAnnotations;

namespace WasmStore.Shared
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string? Email { get; set; }

        [Required]
        public byte[]? HashedPassword { get; set; }

        [Required]
        public byte[]? Salt { get; set; }

        // Navigation properties for relationships
        public ICollection<UserAddress>? UserAddresses { get; set; } = new List<UserAddress>();
        public ICollection<Favourite>? Favourites { get; set; } = new List<Favourite>();
        public ICollection<Order>? Orders { get; set; } = new List<Order>();
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; } = new List<ShoppingCart>();
        public ICollection<Review>? Reviews { get; set; } = new List<Review>();
        public ICollection<Report>? Reports { get; set; } = new List<Report>();
    }
}
