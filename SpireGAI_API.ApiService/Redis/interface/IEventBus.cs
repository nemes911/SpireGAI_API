namespace SpireGAI_API.ApiService.Redis;

public interface IEventBus
{
   public Task PublishAsync<T>(string chanel, T @event);

    public void Subscribe<T>(string chanel, IEventHandler<T> handler);
}
