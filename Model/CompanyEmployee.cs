using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyEmployee
    {
        [Key]
        public int EmployeeID { get; set;}

        public string EmployeeName { get; set;}

        public string EmployeeAddress { get; set;}

        public string EmployeeEmail { get; set;}

        public string EmployeePhone { get; set;}

        public string EmployeeDepartment { get; set;}

        public string EmployeePosition { get; set;}

        public decimal EmployeeSalary { get; set;}

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users users { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }

    }
}
