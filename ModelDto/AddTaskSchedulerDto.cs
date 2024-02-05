using CustomerRelationshipManagementBackend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerRelationshipManagementBackend.ModelDto
{
    public class AddTaskSchedulerDto
    {
        [Key]
        public int? SchedulerId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Task Status is required")]
        public int Taskstatus { get; set; }

        [Required(ErrorMessage = "Date on Schedule is required")]
        public string DateOnSchedule { get; set; }
    }
}
