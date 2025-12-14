using System.Text.Json;
using DistributedTaskScheduler.Api.Services;
using DistributedTaskScheduler.Core;
using DistributedTaskScheduler.Core.Interfaces;
using DistributedTaskScheduler.Core.Models;

public class TaskService(IMessagePublisher publisher) : ITaskService
{
    private readonly IMessagePublisher _publisher = publisher;

    public async Task SubmitJob(TaskRequest taskRequest)
    {
        string routingKey = taskRequest.GetType().Name.Replace("TaskRequest", "");
        await _publisher.PublishAsync(routingKey, taskRequest);
    }

    public async Task SubmitBatchJobs(BatchTaskRequest batchTaskRequest, Type taskType)
    {
        for (int i = 0; i < batchTaskRequest.Amount; i++)
        {
            var taskRequest = GenerateRandomTaskRequest(taskType, i);
            await SubmitJob(taskRequest);
        }
    }

    private static TaskRequest GenerateRandomTaskRequest(Type taskType, int number)
    {
        return taskType switch
        {
            var t when t == typeof(EmailTaskRequest) =>
                new EmailTaskRequest
                {
                    To = $"test@example.com:{number}",
                    Subject = "Hello",
                    Body = "Test body"
                },

            var t when t == typeof(FileProcessingTaskRequest) =>
                new FileProcessingTaskRequest
                {
                    FilePath = "/tmp/file.txt",
                    Operation = "Process"
                },

            _ => throw new ArgumentException($"Unsupported task type: {taskType.Name}")
        };
    }
}