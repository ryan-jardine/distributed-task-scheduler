using DistributedTaskScheduler.Core.Models;

namespace DistributedTaskScheduler.Core;

public static class TaskTypeNames
{
    public const string Email = "Email";
    public const string FileProcessing = "FileProcessing";
    public const string ImageConversion = "ImageConversion";

    private static readonly Dictionary<Type, string> _typeMap = new()
    {
        { typeof(EmailTaskRequest), Email },
        { typeof(FileProcessingTaskRequest), FileProcessing },
    };

    public static bool IsValid(TaskRequest taskRequest)
        => _typeMap.ContainsKey(taskRequest.GetType());

    public static string GetTaskType(TaskRequest taskRequest)
        => _typeMap[taskRequest.GetType()];
}
