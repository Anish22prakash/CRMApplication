using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class ClientRequirements
    {
        [Key]
        public int ClientRequirementsId { get; set; }

        [Required(ErrorMessage = "Client Requirements Name is required")]
        public string ClientRequirementsName { get; set; }

        [Required(ErrorMessage = "Client Requirements Price is required")]
        public decimal ClientRequirementsPrice { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Projects Project { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        public decimal TotalPrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
