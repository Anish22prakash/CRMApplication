using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string? CustomerAddress {  get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }

        public ICollection<Bills> bills { get; set; }

    }
}
