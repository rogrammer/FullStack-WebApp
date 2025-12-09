using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Models;


namespace ProjectManagementAPI.Services
{
    public interface ITaskService
    {
        Task<ProjectTask> CreateTaskAsync(CreateProjectTaskDto dto);
        Task<List<ProjectTask>> GetTasksByProjectAsync(int projectId);
        Task DeleteTaskAsync(int id);
        Task UpdateTaskAsync(int id, UpdateProjectTaskDto dto);
        Task PatchTaskAsync(int id);
    }
}