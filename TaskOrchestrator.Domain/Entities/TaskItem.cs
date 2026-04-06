namespace TaskOrchestrator.Domain.Entities;
using System.Text.Json.Serialization;

public class TaskItem
{
    [JsonIgnore] // This hides it from the Swagger UI input
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public void MarkAsComplete()
    {
        if (IsCompleted) throw new Exception("Task is already completed.");
        IsCompleted = true;
    }
}