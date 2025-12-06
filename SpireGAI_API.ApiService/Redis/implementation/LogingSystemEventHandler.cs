using SpireGAI_API.ApiService.Redis.models;

namespace SpireGAI_API.ApiService.Redis.implementation
{
    public class LogingSystemEventHandler : IEventHandler<LoginSystemEvent>
    {
        public Task HandleAsync(LoginSystemEvent payload)
        {
            Console.WriteLine($"Пользователь {payload.name} вошёл в систему в {DateTime.UtcNow}");

            return Task.CompletedTask;
        }
    }
}
