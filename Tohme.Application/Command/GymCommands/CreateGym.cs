using FluentValidation;

using Mapster;

using MediatR;

using Tohme.Application.Dto;
using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.GymCommands
{
    public record CreateGym(int? Id, string Name) : IRequest<GymDto>;
    public class CreateGymHandler : IRequestHandler<CreateGym, GymDto>
    {
        private readonly IBaseRepository<Gym> _gyms;
        public CreateGymHandler(IBaseRepository<Gym> gyms)
        {
            _gyms = gyms;
        }

        public async Task<GymDto> Handle(CreateGym request, CancellationToken cancellationToken)
        {
            var (id, name) = request;
            var gym = await _gyms.GetNullableById(id, cancellationToken);
            gym?.Update(name);
            gym ??= new Gym(name);
            gym = await _gyms.CreateOrUpdate(id, gym, cancellationToken);
            return gym.Adapt<GymDto>();
        }

    }
    public class CreateGymValidator : AbstractValidator<CreateGym>
    {
        public CreateGymValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }

}
