using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyUltity
    {
        [Key]
        public int CompanyUltityId { get; set; }

        [Required(ErrorMessage = "Utility Name is required")]
        public string UltityName { get; set; }

        [Required(ErrorMessage = "Utility Price is required")]
        public decimal UltityPrice { get; set; }

        [Required(ErrorMessage = "Utility Description is required")]
        public string UltityDescription { get; set; }

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
