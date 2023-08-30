using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.ProteinCommands
{
    public record CreateProtein(int? id, string Name) : IRequest<Protein>;
    public class CreateProteinHandler : IRequestHandler<CreateProtein, Protein>
    {
        private readonly IBaseRepository<Protein> _proteins;
        public CreateProteinHandler(IBaseRepository<Protein> proteins)
        {
            _proteins = proteins;
        }

        public async Task<Protein> Handle(CreateProtein request, CancellationToken cancellationToken)
        {
            var (id, name) = request;
            var protein = await _proteins.GetNullableById(id, cancellationToken);
            protein?.Update(name);
            protein ??= new Protein(name);
            return await _proteins.CreateOrUpdate(id, protein, cancellationToken);
        }
    }
}
