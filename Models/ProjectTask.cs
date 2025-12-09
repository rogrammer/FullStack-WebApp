namespace ProjectManagementAPI.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Descritption { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public Project project { get; set; } = null!;
    }
}