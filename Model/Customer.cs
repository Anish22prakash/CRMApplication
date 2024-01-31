using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        public string? CustomerAddress { get; set; }

        [Required(ErrorMessage = "Customer Mobile is required")]
        public string CustomerMobile { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmail { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }

        public ICollection<Bills> Bills { get; set; }
    }
}
