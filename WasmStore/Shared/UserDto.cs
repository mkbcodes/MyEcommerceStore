using System.ComponentModel.DataAnnotations;
namespace WasmStore.Shared
{
    public class UserDto
    {
        public string? Id { get; set; } // IdentityUser uses string for Id

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string? Email { get; set; }
    }
}


