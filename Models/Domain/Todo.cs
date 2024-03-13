namespace Todo_Web.API.Models.Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public required string Label { get; set; }
        public string? Description { get; set; }
        public required bool Status { get; set; }
        
    }
}