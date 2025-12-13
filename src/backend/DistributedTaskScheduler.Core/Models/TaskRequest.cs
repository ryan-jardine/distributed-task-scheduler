
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace DistributedTaskScheduler.Core.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "taskType")]
[JsonDerivedType(typeof(EmailTaskRequest), typeDiscriminator: TaskTypeNames.Email)]
[JsonDerivedType(typeof(FileProcessingTaskRequest), typeDiscriminator: TaskTypeNames.FileProcessing)]
[SwaggerDiscriminator("taskType")]
public class TaskRequest
{

}
[SwaggerSubType(typeof(EmailTaskRequest), DiscriminatorValue = TaskTypeNames.Email)]
public class EmailTaskRequest : TaskRequest
{
    [Required]
    public required string To { get; set; } = string.Empty;
    [Required]
    public required string Subject { get; set; } = string.Empty;
    [Required]
    public required string Body { get; set; } = string.Empty;
}

[SwaggerSubType(typeof(FileProcessingTaskRequest), DiscriminatorValue = TaskTypeNames.FileProcessing)]
public class FileProcessingTaskRequest : TaskRequest
{
    [Required]
    public required string FilePath { get; set; } = string.Empty;
    [Required]
    public required string Operation { get; set; } = string.Empty;
}