using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command
{
    public record CreateGym(int? id, string Name) : IRequest<Gym>;
    public class CreateGymHandler : IRequestHandler<CreateGym, Gym>
    {
        private readonly IGymRepository _gyms;
        public CreateGymHandler(IGymRepository gyms)
        {
            _gyms = gyms;
        }

        public async Task<Gym> Handle(CreateGym request, CancellationToken cancellationToken)
        {
            var (id, name) = request;
            var gym = await _gyms.GetById(id, cancellationToken);
            gym?.Update(name);
            gym ??= new Gym(name);
            return await _gyms.CreateOrUpdate(gym, cancellationToken);
        }
    }


}
