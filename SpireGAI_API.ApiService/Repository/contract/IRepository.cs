using MediatR;

namespace SpireGAI_API.ApiService.Repository.contract;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
