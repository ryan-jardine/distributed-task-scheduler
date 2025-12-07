using System.Text;
using System.Text.Json;
using DistributedTaskScheduler.Core.Interfaces;
using RabbitMQ.Client;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    public async Task PublishAsync(string routingKey, object message)
    {
        try
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync("tasks", ExchangeType.Direct);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(
                exchange: "tasks",
                routingKey: routingKey,
                body: body
            );
        }
        catch (Exception ex)
        {

        }
    }
}
