using Mapster;

using MediatR;

using Pluralize.NET;

using Tohme.Application.Dto;
using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Queries
{
    public record DisplayGym(int gymId) : IRequest<GymDto>;
    public class DisplayGymHandler : IRequestHandler<DisplayGym, GymDto>
    {
        private readonly IBaseRepository<Gym> _gyms;
        public DisplayGymHandler(IBaseRepository<Gym> gyms)
        {
            _gyms = gyms;
        }

        public async Task<GymDto> Handle(DisplayGym request, CancellationToken cancellationToken)
        {

            var gym = await _gyms.GetById(request.gymId, new string[] { new Pluralizer().Pluralize(nameof(Trainer)) }, cancellationToken);
            return gym.Adapt<GymDto>();
        }
    }
}
