using CustomerRelationshipManagementBackend.ModelDto;
using CustomerRelationshipManagementBackend.Service.TaskSchedulerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerRelationshipManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksSchedulerController : ControllerBase
    {
        private readonly ITaskSchedulerService _tSchedulerService;

        public TasksSchedulerController(ITaskSchedulerService tSchedulerService)
        {
            _tSchedulerService = tSchedulerService;
        }

        [HttpGet , Route("GetTasks")]
        public async  Task<IActionResult> GetTasks(int userId , int TaskStatus = 0 , string? date="")
        {
            try
            {
                if (userId > 0) { 
                    var data = await _tSchedulerService.GetAllTasks(userId, TaskStatus, date);
                    if (data.Count > 0)
                    {
                        return Ok(new { success = true, statusCode = 200, data = data });
                    }
                }
                return Ok(new { success = false, statusCode = 400, error = "no task found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }


        [HttpPost, Route("AddTasks")]
        public async Task<IActionResult> AddTasks(AddTaskSchedulerDto addTaskSchedulerDto)
        {
            try
            {
                var data = await _tSchedulerService.AddTask(addTaskSchedulerDto);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "task not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

        [HttpPost, Route("UpdateTasks")]
        public async Task<IActionResult> UpdateTasks(int TaskId , int ChangeTaskStausId)
        {
            try
            {
                var data = await _tSchedulerService.ChangeTaskStatus(TaskId , ChangeTaskStausId);
                if (data != null)
                {
                    return Ok(new { success = true, statusCode = 200, data = data });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "task not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

        [HttpDelete, Route("RemoveTask")]
        public async Task<IActionResult> RemoveTask(int taskId)
        {
            try
            {
                var result = await _tSchedulerService.RemoveTaskById(taskId);

                if (result != null)
                {
                    return Ok(new { success = true, statusCode = 200, message = result });
                }
                else
                {
                    return Ok(new { success = false, statusCode = 400, error = "Task not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, statusCode = 400, error = "Invalid input", details = ex.Message });
            }
        }

    }
}
