using System;
using System.ComponentModel.DataAnnotations;

namespace DistributedTaskScheduler.Core.Models;

public class BatchTaskRequest
{
    [Required]
    public required string TaskType { get; set; }
    [Required]
    public required int Amount { get; set; }
}
