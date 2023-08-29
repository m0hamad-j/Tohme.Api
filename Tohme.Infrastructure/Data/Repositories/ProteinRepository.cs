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
    public class ProteinRepository:IProteinRepository
    {
        private readonly AppDbContext _context;
        public ProteinRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Protein> CreateOrUpdate(Protein protein, CancellationToken cancellationToken)
        {
            if (protein.Id != 0)
            {
                protein = _context.Update(protein).Entity;
            }
            else
            {
                protein = _context.Add(protein).Entity;

            }
            await _context.SaveChangesAsync(cancellationToken);
            return protein;
        }

        public Task<Protein?> GetById(int? id, CancellationToken cancellationToken)
        {
            return _context.Proteins.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
