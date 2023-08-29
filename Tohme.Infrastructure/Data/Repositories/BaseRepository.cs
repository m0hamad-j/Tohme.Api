using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;
using Tohme.Shared.Abstraction;

namespace Tohme.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {

        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateOrUpdate(int? id, TEntity entity, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                _context.Add(entity);
            }
            else
            {
                _context.Update(entity);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity?> GetNullableById(int? id, CancellationToken cancellationToken)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        public async Task<TEntity> GetById(int? id, CancellationToken cancellationToken)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) ?? throw new Exception("Item not found");

        public async Task<TEntity> UpdateGym(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
