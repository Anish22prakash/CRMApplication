using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyClient
    {
        [Key]
        public int ClientId { get; set; }

        public string CompanyName { get; set; }

        public string? CompanyEmail { get; set;}

        public string? CompanyPhone { get; set;}

        public string CompanyAddress { get; set;}

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
