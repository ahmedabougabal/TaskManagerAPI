using FastEndpoints;
using TaskManagerAPI.DomainTransferObjects;
using TaskManagerAPI.Mappers;
using TaskManagerAPI.Services;
using TaskManagerAPI.Validators;

namespace TaskManagerAPI.Endpoints;

public class CreateTaskEndpoint : Endpoint<CreateTaskRequest, TaskResponse>
{
    public ITaskService TaskService { get; set; }

    public override void Configure()
    {
        Post("/api/tasks");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create a new task";
            s.Description = "Creates a new task with the specified title, description, and due date";
            s.Response(200, "Task created successfully");
            s.Response(400, "Validation failed");
        });
    }

    public override async Task HandleAsync(CreateTaskRequest req, CancellationToken ct)
    {
        // Check if validation failed
        if (ValidationFailed)
        {
            ThrowError("Invalid request"); // This will return a 400 Bad Request with validation errors
            return;
        }

        var taskEntity = TaskMapper.toEntity(req);
        taskEntity = await TaskService.CreateTaskAsync(taskEntity);
        var response = TaskMapper.fromEntity(taskEntity);
        
        await SendOkAsync(response, ct);
    }
}