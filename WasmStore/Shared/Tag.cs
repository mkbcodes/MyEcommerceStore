using System.ComponentModel.DataAnnotations;

namespace WasmStore.Shared
{
    public class Tag
    {
        [Key]
        public int? Id { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public bool? IsApplied { get; set; }

        public ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();
    }
}
