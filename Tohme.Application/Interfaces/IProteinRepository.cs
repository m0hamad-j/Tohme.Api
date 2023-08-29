using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Domain.Entities;

namespace Tohme.Application.Interfaces
{
    public interface IProteinRepository
    {
        Task<Protein> CreateOrUpdate(Protein protein, CancellationToken cancellation);
        Task<Protein?> GetById(int? id, CancellationToken cancellationToken);
    }
}
