namespace ProjectManagementAPI.DTOs
{
    public class CreateProjectTaskDto
    {
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Descritption { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}