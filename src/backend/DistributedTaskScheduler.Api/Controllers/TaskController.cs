using System.Text.Json;
using DistributedTaskScheduler.Api.Examples;
using DistributedTaskScheduler.Api.Services;
using DistributedTaskScheduler.Core;
using DistributedTaskScheduler.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace DistributedTaskScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;

        [HttpPost]
        [SwaggerOperation(Summary = "Submit a task", Description = "Allowed task types: Email, FileProcessing")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid taskType")]

        public async Task<IActionResult> SubmitTask([FromBody] TaskRequest taskRequest)
        {
            try
            {
                if (!TaskTypeNames.IsValid(taskRequest))
                {
                    return BadRequest("Invalid task type");
                }

                await _taskService.SubmitJob(taskRequest);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("batch")]
        [SwaggerOperation(Summary = "Submit a batch of tasks", Description = "Submit multiple random tasks in a single request with random durations.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid taskType")]
        public async Task<IActionResult> SubmitBatchTasks([FromBody] BatchTaskRequest batchTaskRequest)
        {
            try
            {
                if (!TaskTypeMap.TryGetType(batchTaskRequest.TaskType, out var taskType))
                {
                    return BadRequest("Invalid task type");
                }

                await _taskService.SubmitBatchJobs(batchTaskRequest, taskType);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}