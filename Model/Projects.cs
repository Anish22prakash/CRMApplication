using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Projects
    {
        public int ProjectId { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public CompanyClient CompanyClient { get; set; }

        public  ICollection<ClientRequirements> Clientrequirements { get; set; }

        public decimal totalPrice { get; set; }

        public int ProjectStatus { get; set; }

        public string ProjectOrderno {  get; set; }

        public decimal PaidPrice { get; set; }

        public decimal DuePrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
