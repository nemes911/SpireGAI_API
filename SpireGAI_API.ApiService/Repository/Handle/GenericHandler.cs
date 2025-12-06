using SpireGAI_API.ApiService.Repository.contract;
using MediatR;
using SpireGAI_API.ApiService.Repository.command;

namespace SpireGAI_API.ApiService.Repository.Handle
{
    public class GenericHandler<TEntity, TKey> :
        IRequestHandler<AddCommand<TEntity>, TEntity>,
        IRequestHandler<DeleteCommand<TEntity>, TEntity>,
        IRequestHandler<UpdateCommand<TEntity>, TEntity>
        where TEntity : class
    {
        private readonly IRepository<TEntity, TKey> _repository;

        public GenericHandler(IRepository<TEntity, TKey> repository) 
        {
            _repository = repository;
        }

        public async Task<TEntity> Handle(AddCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.entity);

            return request.entity;
        }

        public async Task<TEntity> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.entity);

            return request.entity;
        }

        public async Task<TEntity> Handle(UpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.entity);

            return request.entity;
        }
    }
}
