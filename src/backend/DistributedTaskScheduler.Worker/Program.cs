using DistributedTaskScheduler.Core;
using DistributedTaskScheduler.Worker.Services;

// args is automatically available in top-level programs
if (args.Length == 0)
{
    Console.WriteLine("Usage: worker <RoutingKey>");
    return;
}

var taskType = args[0]; // "Email"

if (taskType != TaskTypeNames.Email &&
    taskType != TaskTypeNames.FileProcessing)
{
    throw new ArgumentException($"Unknown task type: {taskType}");
}


// Create the receiver
var receiver = new RabbitMqMessageReceiver();

// Start receiving messages for the provided routing key
await receiver.ReceiveAsync(taskType);