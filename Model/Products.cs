using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductUniqueCode { get; set; }

        public int SuppliesId { get; set; }

        [ForeignKey(nameof(SuppliesId))]
        public Suppliers suppliers { get; set; }

        public string? ProductPicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProductImage { get; set; }

        public int Quantity { get; set; }

        public decimal? ProductPrice { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }

    }
}
