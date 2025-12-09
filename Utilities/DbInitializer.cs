using ProjectManagementAPI.Data;
using ProjectManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjectManagementAPI.Utilities
{
    public class DbInitializer
    {
        // This method assumes you have an instance of TaskManagerDBContext named 'context'
        public static async Task SeedInitialDataAsync(TaskManagerDBContext context)
        {
            // Ensure the database is created and up to date (optional, usually done in Program.cs)
            // await context.Database.MigrateAsync();

            // 1. Check if data already exists to prevent duplicate entries
            if (await context.Projects.AnyAsync())
            {
                Console.WriteLine("Database already contains data. Skipping seeding.");
            }

            Console.WriteLine("Seeding initial project and task data...");

            // --- Define Projects ---
            var project1 = new Project
            {
                ProjectName = "API Development Project",
                Details = "Build the core REST API for project management.",
                CreatedAt = DateTime.Now
            };

            var project2 = new Project
            {
                ProjectName = "Frontend React App",
                Details = "Develop the user interface using React to consume the API.",
                CreatedAt = DateTime.Now.AddDays(-7)
            };

            // Add projects to context
            await context.Projects.AddRangeAsync(project1, project2);
            await context.SaveChangesAsync(); // Save projects first to get their generated IDs

            // --- Define Tasks and Relate Them ---
            var task1 = new ProjectTask
            {
                ProjectId = project1.Id, // Use the generated ID from project1
                Title = "Setup EF Core and Models",
                Descritption = "Define Project and ProjectTask entities and DbContext.",
                Status = true, // Completed
                DueDate = DateTime.Now.AddDays(-2),
                CreatedAt = DateTime.Now.AddDays(-5)
            };

            var task2 = new ProjectTask
            {
                ProjectId = project1.Id,
                Title = "Implement CRUD for Projects",
                Descritption = "Write services and controllers for basic project operations.",
                Status = false, // Pending
                DueDate = DateTime.Now.AddDays(3),
                CreatedAt = DateTime.Now.AddDays(-4)
            };

            var task3 = new ProjectTask
            {
                ProjectId = project2.Id,
                Title = "Design UI Mockups",
                Descritption = "Create wireframes and mockups for the main dashboard.",
                Status = false,
                DueDate = DateTime.Now.AddDays(10),
                CreatedAt = DateTime.Now.AddDays(-6)
            };

            // Add tasks to context
            await context.ProjectTasks.AddRangeAsync(task1, task2, task3);
            await context.SaveChangesAsync();

            Console.WriteLine("Seeding complete. 2 Projects and 3 Tasks added.");
        }
    }
}