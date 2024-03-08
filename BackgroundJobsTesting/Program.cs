using BackgroundJobsTesting;
using Pilgaard.BackgroundJobs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBackgroundJobs()
    .AddJob<CronJob>();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();