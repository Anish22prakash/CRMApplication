using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class ClientRequirements
    {
        [Key]
        public int ClientRequirementsId { get; set; }

        public string ClientRequirementsName { get; set; }

        public decimal ClientRequirementsPrice { get; set;}

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Projects projects { get; set; }

        public int Qunatity { get; set; }

        public decimal TotalPrice { get;set;}

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
