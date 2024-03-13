namespace Todo_Web.API.Models.DTO
{
    public class UpdateTodoRequiestDto
    {
        public Guid Id { get; set; }
        public required string Label { get; set; }
        public string? Description { get; set; }
        public required bool Status { get; set; }
    }
}
