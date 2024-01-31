using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyClient
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        public string? CompanyEmail { get; set; }

        public string? CompanyPhone { get; set; }

        [Required(ErrorMessage = "Company Address is required")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }

    }
}
