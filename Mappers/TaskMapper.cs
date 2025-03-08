using TaskManagerAPI.DomainTransferObjects;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Mappers;

public class TaskMapper
{
    public static TaskEntity toEntity(CreateTaskRequest req)
    {
        return new TaskEntity
        {
            Title = req.Title,
            Description = req.Description,
            DueDate = req.DueDate,
        };
    }
}