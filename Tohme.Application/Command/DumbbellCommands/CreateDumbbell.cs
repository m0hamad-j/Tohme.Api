using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.DumbbellCommands
{

    public record CreateDumbbell(int? id, int weight) : IRequest<Dumbbell>;
    public class CreateDumbbellHandler : IRequestHandler<CreateDumbbell, Dumbbell>
    {
        private readonly IBaseRepository<Dumbbell> _dumbbell;
        public CreateDumbbellHandler(IBaseRepository<Dumbbell> dumbbell)


        {
            _dumbbell = dumbbell;
        }

        public async Task<Dumbbell> Handle(CreateDumbbell request, CancellationToken cancellationToken)
        {
            var (id, weight) = request;
            var dumbbell = await _dumbbell.GetNullableById(id, cancellationToken);
            dumbbell?.Update(weight);
            dumbbell ??= new Dumbbell(weight);
            return await _dumbbell.CreateOrUpdate(id, dumbbell, cancellationToken);
        }
    }

}
