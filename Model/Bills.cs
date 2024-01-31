using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Bills
    {
        public int BillsId { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public ICollection<Purchase> purchases { get; set; }

        public int status { get; set; }

        [Required]
        public string billUniqueCode { get; set; }

        public decimal SGSTAmount { get; set; }

        public decimal CGSTAmount { get; set; }

        public decimal SGSTPercentage { get; set; }

        public decimal CGSTPercentage { get; set; }

        public decimal TotalDiscountPercentage { get; set; }

        public decimal TotalDiscountAmount { get; set; }


        public decimal TotalBillAmount { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
