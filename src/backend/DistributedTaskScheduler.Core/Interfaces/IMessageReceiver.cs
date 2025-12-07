using System;

namespace DistributedTaskScheduler.Core.Interfaces;

public interface IMessageReceiver
{
    Task ReceiveAsync(string routingKey);
}
