using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.TraineeCommands
{
    public record CreateTrainee(int? id, string Name, int Age) : IRequest<Trainee>;
    public class CreateTraineeHandler : IRequestHandler<CreateTrainee, Trainee>
    {
        private readonly IBaseRepository<Trainee> _trainees;
        public CreateTraineeHandler(IBaseRepository<Trainee> trainees)
        {
            _trainees = trainees;
        }

        public async Task<Trainee> Handle(CreateTrainee request, CancellationToken cancellationToken)
        {
            var (id, name, age) = request;
            var trainee = await _trainees.GetNullableById(id, cancellationToken);
            trainee?.Update(name, age);
            trainee ??= new Trainee(name, age);
            return await _trainees.CreateOrUpdate(id, trainee, cancellationToken);
        }
    }
}
