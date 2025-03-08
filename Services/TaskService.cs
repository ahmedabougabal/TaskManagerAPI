using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services;

public class TaskService : ITaskService
{
    // using an in-memory storage 
    private readonly List<TaskEntity> _tasks = new();

    public Task<TaskEntity> CreateTaskAsync(TaskEntity task)
    {
        task.TaskId = Guid.NewGuid();
        _tasks.Add(task);
        return Task.FromResult(task);
    }

}