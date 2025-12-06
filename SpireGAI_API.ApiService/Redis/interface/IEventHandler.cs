namespace SpireGAI_API.ApiService.Redis;

public interface IEventHandler<T> 
{
    public Task HandleAsync(T payload);
}
