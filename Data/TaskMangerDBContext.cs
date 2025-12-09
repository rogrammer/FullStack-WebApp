using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Data
{
    public class TaskManagerDBContext : DbContext
    {
        public TaskManagerDBContext(DbContextOptions<TaskManagerDBContext> options)
: base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        /*         protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    //don't need this because of Id notation
                    modelBuilder.Entity<Project>().HasKey(p => p.Id);
                    modelBuilder.Entity<Task>().HasKey(t => t.Id);


                    // one-many relation
                    modelBuilder.Entity<ProjectTask>()
                        .HasOne(t => t.Project)
                        .WithMany(p => p.Tasks)
                        .HasForeignKey(t => t.ProjectId);
                } */
    }
}