using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Services;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectTaskController(ITaskService service) : ControllerBase
    {


        [HttpPost("/api/projects/{projectId}/tasks")]
        public async Task<IActionResult> CreateTask(int projectId, CreateProjectTaskDto dto)
        {
            dto.ProjectId = projectId;
            var result = await service.CreateTaskAsync(dto);
            return Ok(result);
        }

        [HttpGet("/api/projects/{projectId}/tasks")]
        public async Task<IActionResult> GetTasks(int projectId)
        {
            return Ok(await service.GetTasksByProjectAsync(projectId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateProjectTaskDto dto)
        {
            await service.UpdateTaskAsync(id, dto);
            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> PatchTask(int id)
        {
            await service.PatchTaskAsync(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await service.DeleteTaskAsync(id);
            return NoContent();
        }

    }
}