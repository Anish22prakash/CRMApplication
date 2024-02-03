using CustomerRelationshipManagementBackend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class AddSupplierDto
    {
        [Key]
        public int? SuppliesId { get; set; }

        [Required(ErrorMessage = "Supplier Name is required")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Supplier Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string SupplierEmail { get; set; }

        [Required(ErrorMessage = "Supplier Mobile is required")]
        public string SupplierMobile { get; set; }

        public string? SupplierAddress { get; set; }

        public string? SupplierCompanyName { get; set; }

        public string? SupplierCompanyAddress { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

    }
}
