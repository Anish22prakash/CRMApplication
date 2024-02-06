using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class UpdateSupplierDto
    {
        [Required(ErrorMessage = "SuppliesId is required")]
        public int SuppliesId { get; set; }

        public string? SupplierName { get; set; }

        public string? SupplierMobile { get; set; }

        public string? SupplierEmail { get; set; }

        public string? SupplierAddress { get; set; }

        public string? SupplierCompanyName { get; set; }

        public string? SupplierCompanyAddress { get; set; }
    }
}
