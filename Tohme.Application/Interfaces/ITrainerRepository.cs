using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tohme.Domain.Entities;

namespace Tohme.Application.Interfaces
{
    public interface ITrainerRepository
    {
        Task<Trainer> CreateOrUpdate(Trainer trainer, CancellationToken cancellation);
        Task<Trainer?> GetNullableById(int? id, CancellationToken cancellationToken);
    }
}
