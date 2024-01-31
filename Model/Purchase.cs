using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public int BillsId { get; set; }

        [ForeignKey(nameof(BillsId))]
        public Bills bills { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Products Products { get; set; }

        public int Quantity { get; set; }

        public decimal TotalItemPrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
