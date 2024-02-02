using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class UserRegisterDto
    {
        [Key]
        public int? UserID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string? UserCompanyName { get; set; }

        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmail { get; set; }

      
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }

        public string? UserMobile { get; set; }

        public string? UserAddress { get; set; }

        public string? UserCompanyAddress { get; set; }

        [Required(ErrorMessage = "Role ID is required")]
        public int RoleId { get; set; }

        [AllowNull]
        public string? ProfilePicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

    }
}
