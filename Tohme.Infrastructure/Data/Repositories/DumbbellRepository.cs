using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data.Repositories
{
    public class DumbbellRepository : IDumbbellRepository
    {
        private readonly AppDbContext _context;
        public DumbbellRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dumbbell> CreateOrUpdate(Dumbbell dumbbell, CancellationToken cancellationToken)
        {
            if (dumbbell.Id != 0)
            {
                dumbbell = _context.Update(dumbbell).Entity;
            }
            else
            {
                dumbbell = _context.Add(dumbbell).Entity;

            }
            await _context.SaveChangesAsync(cancellationToken);
            return dumbbell;
        }

        public Task<Dumbbell?> GetById(int? id, CancellationToken cancellationToken)
        {
            return _context.Dumbbells.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
