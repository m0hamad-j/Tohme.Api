using Tohme.Shared.Abstraction;

namespace Tohme.Application.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> CreateOrUpdate(int? id, TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> GetById(int? id, CancellationToken cancellationToken);
    }
}
