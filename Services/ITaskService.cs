using TaskManagerAPI.DomainTransferObjects;
using TaskManagerAPI.Entities;

namespace TaskManagerAPI.Services;

public interface ITaskService
{
    Task<TaskEntity> CreateTaskAsync(TaskEntity task);
}