using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class UserLoginDto
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
