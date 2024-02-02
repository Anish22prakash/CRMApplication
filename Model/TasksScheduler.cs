using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class TasksScheduler
    {
        [Key]
        public int SchedulerId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users User { get; set; }

        [Required(ErrorMessage = "Task Status is required")]
        public int Taskstatus { get; set; }

        [Required(ErrorMessage = "Date on Schedule is required")]
        public DateTime DateOnSchedule { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required(ErrorMessage = "Is Enabled is required")]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
