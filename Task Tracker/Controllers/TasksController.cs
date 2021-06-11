using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker.Models.Requests;
using Task_Tracker.Services;

namespace Task_Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }


        /// <summary>
        /// Getting a task by id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>Task model</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.Get(id);
            return Ok(task);
        }

        /// <summary>
        /// Task creating
        /// </summary>
        /// <param name="taskModel">Model with task data</param>
        /// <returns>Created task id</returns>
        [HttpPost]
        public async Task<IActionResult> Create(TaskRequestModel taskModel)
        {
            try
            {
                var id = await _service.Create(taskModel);
                return Ok(new { Success = true, TaskId = id });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updating task data
        /// </summary>
        /// <param name="taskModel">Model with task data</param>
        /// /// <param name="id">Task id</param>
        /// <returns>Task model</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TaskRequestModel taskModel, int id)
        {
            try
            {
                var taskId = await _service.Update(taskModel, id);
                return Ok(new { Success = true, TaskId = taskId });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { Success = true });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
