namespace TaskManagerAPI.DomainTransferObjects;

public class TaskResponse
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public bool isOverdue { get; set; }
}