using System;
using DistributedTaskScheduler.Core.Models;

namespace DistributedTaskScheduler.Core;

public static class TaskTypeMap
{
    private static readonly Dictionary<string, Type> Map = new()
    {
        [TaskTypeNames.Email] = typeof(EmailTaskRequest),
        [TaskTypeNames.FileProcessing] = typeof(FileProcessingTaskRequest)
    };

    public static bool TryGetType(string taskType, out Type type)
        => Map.TryGetValue(taskType, out type);
}
