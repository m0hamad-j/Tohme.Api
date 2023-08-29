using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data
{
    public class GymRepository : IGymRepository
    {
        private readonly AppDbContext _context;
        public GymRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Gym> CreateOrUpdate(Gym gym, CancellationToken cancellationToken)
        {
            if (gym.Id != 0)
            {
                gym = _context.Update(gym).Entity;
            }
            else
            {
                gym = _context.Add(gym).Entity;

            }
            await _context.SaveChangesAsync(cancellationToken);
            return gym;
        }

        public Task<Gym?> GetById(int? id, CancellationToken cancellationToken)
        {
            return _context.Gyms.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
