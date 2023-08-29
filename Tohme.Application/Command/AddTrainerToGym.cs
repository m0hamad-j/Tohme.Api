using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command
{
    public record AddTrainerToGym(int gymId, int trainerId) : IRequest<Gym>;
    public class AddTrainerToGymHandler : IRequestHandler<AddTrainerToGym, Gym>
    {
        private readonly IBaseRepository<Gym> _gyms;
        private readonly IBaseRepository<Trainer> _trainers;
        public AddTrainerToGymHandler(IBaseRepository<Gym> gyms, IBaseRepository<Trainer> trainers)
        {
            _gyms = gyms;
            _trainers = trainers;
        }
        public async Task<Gym> Handle(AddTrainerToGym request, CancellationToken cancellationToken)
        {
            var (gymId, trainerId) = request;
            var gym = await _gyms.GetNullableById(gymId, cancellationToken);
            var trainer = await _trainers.GetById(trainerId, cancellationToken);
            gym.AddTrainer(trainer);
            return await _gyms.UpdateGym(gym,cancellationToken);
        }
    }
}
