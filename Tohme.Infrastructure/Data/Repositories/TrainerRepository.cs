using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {

        private readonly AppDbContext _context;
        public TrainerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Trainer> CreateOrUpdate(Trainer trainer, CancellationToken cancellationToken)
        {
            if (trainer.Id != 0)
            {
                trainer = _context.Update(trainer).Entity;
            }
            else
            {
                trainer = _context.Add(trainer).Entity;

            }
            await _context.SaveChangesAsync(cancellationToken);
            return trainer;
        }

        public Task<Trainer?> GetNullableById(int? id, CancellationToken cancellationToken)
        {
            return _context.Trainers.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}

