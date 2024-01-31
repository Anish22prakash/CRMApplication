﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string? UserCompanyName { get; set; }

        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password Salt is required")]
        public string PasswordSalt { get; set; }

        [Required(ErrorMessage = "Password Hash is required")]
        public string PasswordHash { get; set; }

        public string? UserMobile { get; set; }

        public string? UserAddress { get; set; }

        public string? UserCompanyAddress { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        public int RoleId { get; set; }

        public string? ProfilePicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
