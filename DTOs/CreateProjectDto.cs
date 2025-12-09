namespace ProjectManagementAPI.DTOs
{
    public class CreateProjectDto
    {
        public string? ProjectName { get; set; }
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}