using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.GymCommands
{
    public record DeleteGym(int id) : IRequest<Unit>;

    internal class DeleteGymHandler : IRequestHandler<DeleteGym, Unit>
    {
        private readonly IBaseRepository<Gym> _gyms;

        public DeleteGymHandler(IBaseRepository<Gym> gyms)
        {
            _gyms = gyms;
        }

        public async Task<Unit> Handle(DeleteGym request, CancellationToken cancellationToken)
        {
            await _gyms.Delete(request.id, cancellationToken);
            return Unit.Value;
        }
    }
}
