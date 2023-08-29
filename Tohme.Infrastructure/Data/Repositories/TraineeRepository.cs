using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data.Repositories
{
    public class TraineeRepository:ITraineeRepository
    {
            private readonly AppDbContext _context;
            public TraineeRepository(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Trainee> CreateOrUpdate(Trainee trainee, CancellationToken cancellationToken)
            {
                if (trainee.Id != 0)
                {
                    trainee = _context.Update(trainee).Entity;
                }
                else
                {
                    trainee = _context.Add(trainee).Entity;

                }
                await _context.SaveChangesAsync(cancellationToken);
                return trainee;
            }

            public Task<Trainee?> GetById(int? id, CancellationToken cancellationToken)
            {
                return _context.Trainees.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
            }
        }
    }

