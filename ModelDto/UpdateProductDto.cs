using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class UpdateProductDto
    {
        [Key]
        [Required]
        public int? ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public string? ProductUniqueCode { get; set; }

        public int? SuppliesId { get; set; }

        public string? ProductPicUrl { get; set; }

        [NotMapped]
        public IFormFile? ProductImage { get; set; }

        public int? Quantity { get; set; }

        public decimal? ProductPrice { get; set; }
    }
}
