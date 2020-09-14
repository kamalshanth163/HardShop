using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos {
    public class AdminRegisterDto {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength (8, MinimumLength = 4, ErrorMessage = "Password should be between 4 and 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public PhoneCreateDto Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public AdminRegisterDto () {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
            Role = "admin";
        }
    }
}