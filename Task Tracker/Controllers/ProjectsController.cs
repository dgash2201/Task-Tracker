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
        /// Getting a project by id
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Success response with project model or bad request response</returns>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _service.Get(id);
            return Ok(project);
        }

        /// <summary>
        /// Project creating
        /// </summary>
        /// <param name="projectModel">Model with project data</param>
        /// <returns>Success response with created task id or bad request response</returns>
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

        /// <summary>
        /// Updating project data
        /// </summary>
        /// <param name="projectModelModel">Model with project data</param>
        /// /// <param name="id">Project id</param>
        /// <returns>Success response or bad request response</returns>
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

        /// <summary>
        /// Deleting project
        /// </summary>
        /// /// <param name="id">Project id</param>
        /// <returns>Success response or bad request response</returns>
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
