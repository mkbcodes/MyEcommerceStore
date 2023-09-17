﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmStore.Shared
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public int? Rating { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required, MaxLength(50)]
        public string? Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}