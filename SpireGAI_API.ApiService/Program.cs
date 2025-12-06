using Microsoft.EntityFrameworkCore;
using SpireGAI_API.ApiService.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var dbConfig = builder.Configuration.GetSection("Database");
var connectionString =
    $"Host={dbConfig["Host"]};Database={dbConfig["Name"]};Username={dbConfig["User"]};Password={dbConfig["Password"]}";

builder.Services.AddDbContext<SpireDbContext>(options =>
    options.UseNpgsql(connectionString));

var redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");

IDatabase db = redis.GetDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
