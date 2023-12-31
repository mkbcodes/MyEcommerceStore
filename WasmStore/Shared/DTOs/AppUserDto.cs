﻿using System.ComponentModel.DataAnnotations;
using WasmStore.Shared.Models;

namespace WasmStore.Shared.DTOs
{
    public class AppUserDto
    {
        public string? Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, MaxLength(100), EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }

    }
}
