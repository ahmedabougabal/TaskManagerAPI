namespace TaskManagerAPI.DomainTransferObjects;

public class CreateTaskRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}