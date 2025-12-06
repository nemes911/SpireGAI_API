using MediatR;

namespace SpireGAI_API.ApiService.Repository.command
{
    public record class AddCommand<TEntity>(TEntity entity) : IRequest<TEntity> where TEntity : class;

    public record class UpdateCommand<TEntity>(TEntity entity) : IRequest<TEntity> where TEntity : class;

    public record class DeleteCommand<TEntity>(TEntity entity) : IRequest<TEntity> where TEntity : class;
}
