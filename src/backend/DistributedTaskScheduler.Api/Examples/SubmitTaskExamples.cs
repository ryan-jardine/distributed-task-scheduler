using System;
using DistributedTaskScheduler.Core.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DistributedTaskScheduler.Api.Examples;

public class EmailTaskExample : IExamplesProvider<EmailTaskRequest>
{
    public EmailTaskRequest GetExamples() => new()
    {
        To = "user@test.com",
        Subject = "Welcome",
        Body = "Hello world"
    };
}
