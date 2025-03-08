using FastEndpoints;
using TaskManagerAPI.DomainTransferObjects;
using TaskManagerAPI.Mappers;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Endpoints;

public class CreateTaskEndpoint : Endpoint<CreateTaskRequest, TaskResponse>
{
    public ITaskService TaskService { get; set; } // dependency injection

    public override void Configure()
    {
        Post("/api/tasks");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateTaskRequest req, CancellationToken ct)
    {
        // maps request DTO to my domain entity using the mapper I created 
        var taskEntity = TaskMapper.toEntity(req);
        
        //use the injected service to create the task
        taskEntity = await TaskService.CreateTaskAsync(taskEntity);
        
        // map the domain entity back to a response DTO
        var response = TaskMapper.fromEntity(taskEntity);
        
        await SendOkAsync(response, ct);
    }
    
}
