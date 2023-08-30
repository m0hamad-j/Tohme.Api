using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command
{
    public record AddTraineeToGym(int gymId, int traineeId) : IRequest<Gym>;
    public class AddTraineeToGymHandler : IRequestHandler<AddTraineeToGym, Gym>
    {
        private readonly IBaseRepository<Gym> _gyms;
        private readonly IBaseRepository<Trainee> _trainees;
        public AddTraineeToGymHandler(IBaseRepository<Gym> gyms, IBaseRepository<Trainee> trainees)
        {
            _gyms = gyms;
            _trainees = trainees;
        }
        public async Task<Gym> Handle(AddTraineeToGym request, CancellationToken cancellationToken)
        {
            var (gymId, traineeId) = request;
            var gym = await _gyms.GetNullableById(gymId, cancellationToken);
            var trainee = await _trainees.GetById(traineeId, cancellationToken);
            gym.AddTrainee(trainee);
            return await _gyms.UpdateGym(gym, cancellationToken);
        }
    }
}
