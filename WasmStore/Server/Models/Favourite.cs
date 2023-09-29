using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WasmStore.Shared.DTOs;

namespace WasmStore.Server.Models
{
    public class Favourite
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();

        [Required]
        public string? ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified {  get; set; }
    }
}
