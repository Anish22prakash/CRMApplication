using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRelationshipManagementBackend.Model
{
    public class TaskScheduler
    {
        [Key]
        public int SchedulerId { get; set; }

        public string description { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public Users users { get; set; }

        public int Taskstatus { get; set; }

        public DateTime DateOnSchedule { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [Required]
        [Display(Name = "Is Enabled")]
        public Boolean IsEnabled { get; set; }
    }
}
