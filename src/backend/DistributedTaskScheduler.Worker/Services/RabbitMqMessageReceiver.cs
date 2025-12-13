using System;
using System.Text;
using DistributedTaskScheduler.Core.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DistributedTaskScheduler.Worker.Services;

public class RabbitMqMessageReceiver : IMessageReceiver
{
    public async Task ReceiveAsync(string routingKey)
    {
        var factory = new ConnectionFactory { HostName = "rabbitmq" };
        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync("tasks", ExchangeType.Direct);

        await channel.QueueDeclareAsync(
            queue: routingKey,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        await channel.QueueBindAsync(routingKey, "tasks", routingKey);

        Console.WriteLine($" [*] Waiting for messages on '{routingKey}'.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received '{ea.RoutingKey}':'{message}'");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync(routingKey, autoAck: true, consumer: consumer);
        await Task.Delay(-1);
    }



}
