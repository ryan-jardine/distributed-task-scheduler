using DistributedTaskScheduler.Api.Examples;
using DistributedTaskScheduler.Api.Services;
using DistributedTaskScheduler.Core;
using DistributedTaskScheduler.Core.Interfaces;
using DistributedTaskScheduler.Core.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IMessagePublisher, RabbitMqMessagePublisher>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.UseOneOfForPolymorphism();
    c.SelectDiscriminatorNameUsing(_ => "taskType");
    c.SelectDiscriminatorValueUsing(type =>
    {
        if (type == typeof(EmailTaskRequest)) return TaskTypeNames.Email;
        if (type == typeof(FileProcessingTaskRequest)) return TaskTypeNames.FileProcessing;
        return null;
    });
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<EmailTaskExample>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
