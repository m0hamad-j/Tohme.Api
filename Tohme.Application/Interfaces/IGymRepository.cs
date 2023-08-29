using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Domain.Entities;

namespace Tohme.Application.Interfaces
{
    public interface IGymRepository
    {
        Task<Gym> CreateOrUpdate(Gym gym, CancellationToken cancellation);
        Task<Gym?> GetById(int? id, CancellationToken cancellationToken);
    }
}
