namespace ProjectManagementAPI.DTOs
{
    public class UpdateProjectTaskDto
    {
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Descritption { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}