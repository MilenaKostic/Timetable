using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTO.User
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        
        public string? Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} and at the max {1} characters long. ", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The passwords do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
