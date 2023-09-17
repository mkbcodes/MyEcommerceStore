using System.ComponentModel.DataAnnotations;

namespace WasmStore.Shared
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string? AddressLine { get; set; }

        [Required, MaxLength(100)]
        public string? City { get; set; }

        [Required, MaxLength(50)]
        public string? Province { get; set; }

        [Required, MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        public ICollection<UserAddress>? UserAddresses { get; set; } = new List<UserAddress>();
    }
}
