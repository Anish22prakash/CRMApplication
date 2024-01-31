using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Bills
    {
        [Key]
        public int BillsId { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Bill Unique Code is required")]
        public string BillUniqueCode { get; set; }

        [Required(ErrorMessage = "SGST Amount is required")]
        public decimal SGSTAmount { get; set; }

        [Required(ErrorMessage = "CGST Amount is required")]
        public decimal CGSTAmount { get; set; }

        [Required(ErrorMessage = "SGST Percentage is required")]
        public decimal SGSTPercentage { get; set; }

        [Required(ErrorMessage = "CGST Percentage is required")]
        public decimal CGSTPercentage { get; set; }

        [Required(ErrorMessage = "Total Discount Percentage is required")]
        public decimal TotalDiscountPercentage { get; set; }

        [Required(ErrorMessage = "Total Discount Amount is required")]
        public decimal TotalDiscountAmount { get; set; }

        [Required(ErrorMessage = "Total Bill Amount is required")]
        public decimal TotalBillAmount { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }

}
