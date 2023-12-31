﻿using System.Runtime.CompilerServices;

using Microsoft.EntityFrameworkCore;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Infrastructure.Data.Repositories
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
        public async Task<Gym> UpdateGym(Gym gym, CancellationToken cancellationToken)
        {
            gym = _context.Update(gym).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return gym;
        }
        public async Task<Gym?> GetNullableById(int? id, CancellationToken cancellationToken)
        {
            return await _context.Gyms.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
        public async Task<Gym> GetWithTrainerById(int id, CancellationToken cancellationToken)
            => await _context.Gyms.Include(g => g.Trainers).FirstOrDefaultAsync(g => g.Id == id, cancellationToken) ?? throw new Exception("Item not found");

        public Task<Gym?> GetById(int? id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
