using ProjectManagementAPI.Models;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskManagerDBContext _context;

        public TaskService(TaskManagerDBContext context)
        {
            _context = context;
        }

        public async Task<ProjectTask> CreateTaskAsync(CreateProjectTaskDto dto)
        {
            var task = new ProjectTask
            {
                ProjectId = dto.ProjectId,
                Title = dto.Title,
                Descritption = dto.Descritption,
                Status = dto.Status,
                DueDate = dto.DueDate,
                CreatedAt = dto.CreatedAt,
            };

            _context.ProjectTasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var taskToDelete = await _context.ProjectTasks.FindAsync(id);

            if (taskToDelete != null)
            {
                _context.ProjectTasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProjectTask>> GetTasksByProjectAsync(int projectId)
        {
            return await _context.ProjectTasks
                    .Where(t => t.ProjectId == projectId)
                    .ToListAsync();
        }

        public async Task PatchTaskAsync(int id)
        {
            var taskToPatch = await _context.ProjectTasks.FindAsync(id);

            if (taskToPatch == null)
                return;

            if (taskToPatch.Status == false)
            {
                taskToPatch.Status = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTaskAsync(int id, UpdateProjectTaskDto dto)
        {
            var taskToUpdate = await _context.ProjectTasks.FindAsync(id);

            if (taskToUpdate == null)
            {
                return;
            }

            taskToUpdate.ProjectId = dto.ProjectId;
            taskToUpdate.Title = dto.Title;
            taskToUpdate.Descritption = dto.Descritption;
            taskToUpdate.Status = dto.Status;
            taskToUpdate.DueDate = dto.DueDate;


            await _context.SaveChangesAsync();
        }
    }
}