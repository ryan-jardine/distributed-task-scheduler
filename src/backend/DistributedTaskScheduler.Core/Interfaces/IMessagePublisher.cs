namespace DistributedTaskScheduler.Core.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync(string routingKey, object message);
}