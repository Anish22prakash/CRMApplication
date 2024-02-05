using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class UpdateuserDto
    {
        [Key]
        [Required]
        public int? UserID { get; set; }

       
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        public string? UserCompanyName { get; set; }

        
        public string UserEmail { get; set; }

        public string? UserMobile { get; set; }

        public string? UserAddress { get; set; }

        public string? UserCompanyAddress { get; set; }

       
        [AllowNull]
        public string? ProfilePicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

      

    }
}
