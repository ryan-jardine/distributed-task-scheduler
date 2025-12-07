
using System.Text.Json;
namespace DistributedTaskScheduler.Api.Services
{
    public interface ITaskService
    {
        Task SubmitJob(TaskRequest taskRequest);
    }
}
