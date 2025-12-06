using SpireGAI_API.ApiService.Redis.models;

namespace SpireGAI_API.ApiService.Redis.implementation
{
    public class AddNewUserEventHandler : IEventHandler<AddNewUserEvent>
    {
        public Task HandleAsync(AddNewUserEvent payload)
        {
           

            return Task.CompletedTask;
        }
    }
}
