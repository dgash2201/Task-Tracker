using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;
using Task_Tracker.Services;

namespace Task_Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// Getting a task by id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns>Success response with task model or bad request response</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _service.Get(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRequestModel projectModel)
        {
            try
            {
                var id = await _service.Create(projectModel);
                return Ok(new { Success = true, ProjectId = id });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectRequestModel projectModel, int id)
        {
            try
            {
                await _service.Update(projectModel, id);
                return Ok(new { Success = true });
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
