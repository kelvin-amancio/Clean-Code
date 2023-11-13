﻿using System.ComponentModel.DataAnnotations;

namespace Clean.API.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password don´t match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
