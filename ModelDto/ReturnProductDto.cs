using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class ReturnProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Product Unique Code is required")]
        public string ProductUniqueCode { get; set; }

        [Required(ErrorMessage = "Supplies ID is required")]
        public int SuppliesId { get; set; }

        public string? SupplierName { get; set; }

        public string? SupplierMobile {  get; set; }

        public string? ProductPicUrl { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        public decimal? ProductPrice { get; set; }
    }
}
