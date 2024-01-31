using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyUltity
    {
        [Key]
        public int CompanyUltityId { get; set; }

        public string UltityName { get; set; }

        public decimal UltityPrice { get; set; }

        public string UltityDescription { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users users { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
