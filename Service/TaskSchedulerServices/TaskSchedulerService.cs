using AutoMapper;
using CustomerRelationshipManagementBackend.Common;
using CustomerRelationshipManagementBackend.Data;
using CustomerRelationshipManagementBackend.Model;
using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.SuppliersServices;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CustomerRelationshipManagementBackend.Service.TaskSchedulerServices
{
    public class TaskSchedulerService : ITaskSchedulerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskSchedulerService> _logger;
       
        public TaskSchedulerService(ApplicationDbContext context, IMapper mapper, ILogger<TaskSchedulerService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TasksScheduler> AddTask(AddTaskSchedulerDto taskSchedulerDto)
        {
            try
            {
                string format = "yyyy-MM-dd HH:mm:ss"; 

               DateTime dateTime = DateTime.ParseExact(taskSchedulerDto.DateOnSchedule, format, CultureInfo.InvariantCulture);
                var newTask = _mapper.Map<AddTaskSchedulerDto, TasksScheduler>(taskSchedulerDto);
               newTask.CreatedDateTime = DateTime.Now;
               newTask.UpdatedDateTime = DateTime.Now;
                newTask.DateOnSchedule = dateTime;
                newTask.IsEnabled = true;
                newTask.Taskstatus = Convert.ToInt32(Enums.TaskStatus.Pending);

               await _context.TasksScheduler.AddAsync(newTask);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"added task{taskSchedulerDto.UserID} successfully");
                return newTask;
            }
            catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "AddTask");
                throw;
            }
            
        }

        public async Task<string> ChangeTaskStatus(int taskId, int TaskstatusId)
        {
            string message = MessagesAlerts.FailUpdate;
            try
            {
              var existingTask = await  _context.TasksScheduler.FirstOrDefaultAsync(u => u.SchedulerId == taskId);
                if (existingTask == null) {
                    _logger.LogInformation($"task not found by {taskId}");
                    return null;
                }
                existingTask.Taskstatus = TaskstatusId;
                existingTask.UpdatedDateTime = DateTime.Now;
                _context.Update(existingTask); 
               await _context.SaveChangesAsync();
                message = MessagesAlerts.SuccessfullUpdate;
                _logger.LogInformation($"task updated {taskId} successfully");
                return message;

            }catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "ChangeTaskStatus");
                throw;
            }
        }

        public async Task<IList<TasksScheduler>> GetAllTasks(int userId, int Taskstatus, string date)
        {
            try
            {
                var query = _context.TasksScheduler.Where( u =>u.UserID == userId).AsQueryable();
                if(query == null)
                {
                    _logger.LogInformation($"not able to retrive task by {userId}");
                    return null;
                }
                if(Taskstatus > 0)
                {
                    query = query.Where(u => u.Taskstatus == Taskstatus);
                }
                if (!string.IsNullOrEmpty(date))
                {
                    string format = "dd-MM-yyyy";
                    DateTime dateTime = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
                    query = query.Where(u => u.DateOnSchedule.Date == dateTime.Date);
                }

                var tasks = await query.ToListAsync();
                _logger.LogInformation($"retived all the task by userId{userId}");
                return tasks;


            }
            catch (Exception ex)
            {
                this._logger.LogError(default(EventId), ex, "GetAllTasks");
                throw;
            }
        }

        public Task<string> RemoveTaskById(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
