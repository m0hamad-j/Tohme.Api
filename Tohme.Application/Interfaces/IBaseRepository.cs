using Tohme.Shared.Abstraction;

namespace Tohme.Application.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        
        Task<TEntity> CreateOrUpdate(int? id, TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> GetById(int? id, CancellationToken cancellationToken);
        Task<TEntity> UpdateGym(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> GetNullableById(int? id, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<TEntity> GetById(int? id, string[] includes, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAll(string[] includes, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
