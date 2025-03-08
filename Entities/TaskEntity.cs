namespace TaskManagerAPI.Entities;

public class TaskEntity
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}