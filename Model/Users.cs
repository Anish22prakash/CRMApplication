using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? UserCompanyName { get; set; }

        public string UserEmail { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordHash { get; set; }

        public string? UserMobile { get; set; }

        public string? UserAddress { get; set; }

        public string? UserCompanyAddress { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string? ProfilePicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }



    }
}
