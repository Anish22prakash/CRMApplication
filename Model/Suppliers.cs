using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Suppliers
    {
        [Key]
        public int SuppliesId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        public string SupplierName { get; set; }

        public string? SupplierEmail { get; set; }

        [Required(ErrorMessage = "Supplier Mobile is required")]
        public string SupplierMobile { get; set; }

        public string? SupplierAddress { get; set; }

        public string? SupplierCompanyName { get; set; }

        public string? SupplierCompanyAddress { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        public ICollection<Products>? Products { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
