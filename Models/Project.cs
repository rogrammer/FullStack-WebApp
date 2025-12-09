namespace ProjectManagementAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string ProjectName { get; set; }
        public string? Details { get; set; }
        public required DateTime CreatedAt { get; set; }
        public ICollection<ProjectTask>? Tasks { get; set; }

    }
}