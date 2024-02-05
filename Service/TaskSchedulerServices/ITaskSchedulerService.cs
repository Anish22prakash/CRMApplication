using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;

namespace CustomerRelationshipManagementBackend.Service.TaskSchedulerServices
{
    public interface ITaskSchedulerService
    {
        public Task<TasksScheduler> AddTask(AddTaskSchedulerDto taskSchedulerDto);
        public Task<string> RemoveTaskById(int taskId);
        public Task<string> ChangeTaskStatus(int taskId, int TaskstatusId);
        public Task<IList<TasksScheduler>> GetAllTasks(int userId, int Taskstatus , string date);
        
    }
}
