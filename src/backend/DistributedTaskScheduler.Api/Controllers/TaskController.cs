using System.Text.Json;
using DistributedTaskScheduler.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistributedTaskScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;

        [HttpPost]
        public async Task<IActionResult> SubmitTask([FromBody] TaskRequest taskRequest)
        {
            try
            {
                await _taskService.SubmitJob(taskRequest);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}