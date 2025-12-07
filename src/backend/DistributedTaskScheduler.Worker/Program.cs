using DistributedTaskScheduler.Worker.Services;

// Create the receiver
var receiver = new RabbitMqMessageReceiver();

// Start receiving messages for the "Email" routing key
await receiver.ReceiveAsync("Email");

// Keep the console app alive
Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();
