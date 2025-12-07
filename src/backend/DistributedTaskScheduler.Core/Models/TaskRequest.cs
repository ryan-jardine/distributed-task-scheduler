
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "taskType")]
[JsonDerivedType(typeof(EmailTaskRequest), typeDiscriminator: "Email")]
[JsonDerivedType(typeof(FileProcessingTaskRequest), typeDiscriminator: "FileProcessing")]
public class TaskRequest
{

}

public class EmailTaskRequest : TaskRequest
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}

public class FileProcessingTaskRequest : TaskRequest
{
    public string FilePath { get; set; } = string.Empty;
    public string Operation { get; set; } = string.Empty;
}