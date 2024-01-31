using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Client ID is required")]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public CompanyClient CompanyClient { get; set; }

        public ICollection<ClientRequirements> ClientRequirements { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Project Status is required")]
        public int ProjectStatus { get; set; }

        [Required(ErrorMessage = "Project Order No is required")]
        public string ProjectOrderno { get; set; }

        [Required(ErrorMessage = "Paid Price is required")]
        public decimal PaidPrice { get; set; }

        [Required(ErrorMessage = "Due Price is required")]
        public decimal DuePrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
