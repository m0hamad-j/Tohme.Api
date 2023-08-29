using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command
{
    public record CreateTrainer(string Name, int Age) : IRequest<Trainer>;
    public class CreateTrainerHandler : IRequestHandler<CreateTrainer, Trainer>
    {
        private readonly ITrainerRepository _trainers;
        public CreateTrainerHandler(ITrainerRepository trainer)
        {
            _trainers = trainer;
        }

        public Task<Trainer> Handle(CreateTrainer request, CancellationToken cancellationToken)
        {
            var trainer = new Trainer(request.Name, request.Age);
            return _trainers.Create(trainer);
        }
    }
}
