using ProjectManagementAPI.Models;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementAPI.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TaskManagerDBContext _context;

        public ProjectService(TaskManagerDBContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                Details = dto.Details,
                CreatedAt = dto.CreatedAt
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects
            .ToListAsync();
        }

        public async Task<Project?> GetProjectWithIdAsync(int id)
        {
            return await _context.Projects
                    .Where(p => p.Id == id)
                    .Include(p => p.Tasks)
                    .FirstOrDefaultAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var projectToDelete = await _context.Projects.FindAsync(id);

            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                await _context.SaveChangesAsync();
            }

            // return code 204 for success

        }

        public async Task UpdateProjectAsync(int id, UpdateProjectDto dto)
        {
            var projectToUpdate = await _context.Projects.FindAsync(id);

            if (projectToUpdate == null)
            {
                // error code will be 404 by controller default value
                return;
            }

            projectToUpdate.ProjectName = dto.ProjectName;
            projectToUpdate.Details = dto.Details;

            await _context.SaveChangesAsync();
        }
    }
}