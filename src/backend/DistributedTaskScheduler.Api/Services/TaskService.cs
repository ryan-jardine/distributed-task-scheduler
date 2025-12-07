using System.Text.Json;
using DistributedTaskScheduler.Api.Services;
using DistributedTaskScheduler.Core.Interfaces;

public class TaskService(IMessagePublisher publisher) : ITaskService
{
    private readonly IMessagePublisher _publisher = publisher;

    public async Task SubmitJob(TaskRequest taskRequest)
    {
        string routingKey = taskRequest.GetType().Name.Replace("TaskRequest", "");
        await _publisher.PublishAsync(routingKey, taskRequest);
    }
}