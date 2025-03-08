using TaskManagerAPI.DomainTransferObjects;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Mappers;

public class TaskMapper
{
    // this is to convert the request DTO to the domain entity
    public static TaskEntity toEntity(CreateTaskRequest req)
    {
        return new TaskEntity
        {
            Title = req.Title,
            Description = req.Description,
            DueDate = req.DueDate,
        };
    }


    // this is to convert the domain entity to the response DTO
    public static TaskResponse fromEntity(TaskEntity entity)
    {
        return new TaskResponse
        {
            TaskId = entity.TaskId,
            Title = entity.Title,
            isOverdue = entity.DueDate < DateTime.Now,
        };
    }
    
    
}