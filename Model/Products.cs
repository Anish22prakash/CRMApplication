using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Product Unique Code is required")]
        public string ProductUniqueCode { get; set; }

        [Required(ErrorMessage = "Supplies ID is required")]
        public int SuppliesId { get; set; }

        [ForeignKey(nameof(SuppliesId))]
        public Suppliers Supplier { get; set; }

        public string? ProductPicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProductImage { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        public decimal? ProductPrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
