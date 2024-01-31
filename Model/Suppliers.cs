﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class Suppliers
    {
        public int SuppliesId { get; set; }

        public string SupplierName { get; set;}

        public string SupplierEmail { get; set; }

        public string SupplierMobile { get; set; }

        public string? SupplierAddress { get; set; }

        public string? SupplierCompanyName { get; set; }

        public string? SupplierCompanyAddress { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users users { get; set; }

        public ICollection<Products>? products { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
