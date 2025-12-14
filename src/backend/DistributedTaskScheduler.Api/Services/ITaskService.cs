using DistributedTaskScheduler.Core.Models;
namespace DistributedTaskScheduler.Api.Services
{
    public interface ITaskService
    {
        Task SubmitJob(TaskRequest taskRequest);
        Task SubmitBatchJobs(BatchTaskRequest batchTaskRequest, Type taskType);
    }
}
