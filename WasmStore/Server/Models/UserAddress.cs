﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Models
{
    public class UserAddress
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string ApplicationUserId { get; set; }  // Changed type to string

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }  // Changed to ApplicationUser

        [Required]
        public Guid AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address? Address { get; set; }
        public AddressType AddressType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
