﻿using System.ComponentModel.DataAnnotations;

namespace WasmStore.Server.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }

        public ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();
    }
}
