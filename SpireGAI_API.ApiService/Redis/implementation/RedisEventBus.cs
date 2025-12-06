using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SpireGAI_API.ApiService.Models;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpireGAI_API.ApiService.Redis.implementation
{
    public class RedisEventBus : IEventBus
    {
        private readonly ISubscriber _subscriber;

        public RedisEventBus(ConnectionMultiplexer redis)
        {
            _subscriber = redis.GetSubscriber();
        }

        public async Task PublishAsync<T>(string chanel, T @event)
        {
            var json = JsonSerializer.Serialize(@event);
            await _subscriber.PublishAsync(chanel, json);
        }

        public void Subscribe<T>(string channel, IEventHandler<T> handler)
        {
            _subscriber.Subscribe(channel, async (ch, msg) =>
            {
                var payload = JsonSerializer.Deserialize<T>(msg);
                if (payload != null)
                {
                    await handler.HandleAsync(payload);
                }
            });
        }
    }
}
