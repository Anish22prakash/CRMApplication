using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class CompanyEmployee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee Address is required")]
        public string EmployeeAddress { get; set; }

        [Required(ErrorMessage = "Employee Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Employee Phone is required")]
        public string EmployeePhone { get; set; }

        [Required(ErrorMessage = "Employee Department is required")]
        public string EmployeeDepartment { get; set; }

        [Required(ErrorMessage = "Employee Position is required")]
        public string EmployeePosition { get; set; }

        [Required(ErrorMessage = "Employee Salary is required")]
        public decimal EmployeeSalary { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
