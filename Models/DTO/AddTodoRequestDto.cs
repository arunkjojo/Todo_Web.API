namespace Todo_Web.API.Models.DTO
{
    public class AddTodoRequestDto
    {
        public required string Label { get; set; }
        public string? Description { get; set; }
        public required bool Status { get; set; }
    }
}
