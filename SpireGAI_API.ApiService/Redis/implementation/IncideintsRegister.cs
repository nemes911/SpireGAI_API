
namespace SpireGAI_API.ApiService.Redis.implementation
{
    public class IncideintsRegister : IEventHandler<IncideintsRegister>
    {
        public Task HandleAsync(IncideintsRegister payload)
        {
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}
