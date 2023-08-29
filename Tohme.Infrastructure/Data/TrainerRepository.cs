using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data
{
    public class TrainerRepository:ITrainerRepository
    {
        
            private readonly AppDbContext _context;
            public TrainerRepository(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Trainer> Create(Trainer trainer)
            {
                var newTrainer = _context.Add(trainer);
                await _context.SaveChangesAsync();
                return newTrainer.Entity;
            }
        }
    }

