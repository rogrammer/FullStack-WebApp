using ProjectManagementAPI.DTOs;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Services
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(CreateProjectDto dto);
        Task<List<Project>> GetProjectsAsync();
        Task<Project?> GetProjectWithIdAsync(int id);
        Task DeleteProjectAsync(int id);
        Task UpdateProjectAsync(int id, UpdateProjectDto dto);
    }
}