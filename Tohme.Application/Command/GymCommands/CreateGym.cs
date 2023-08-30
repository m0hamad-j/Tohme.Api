﻿using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.GymCommands
{
    public record CreateGym(int? Id, string Name) : IRequest<Gym>;
    public class CreateGymHandler : IRequestHandler<CreateGym, Gym>
    {
        private readonly IBaseRepository<Gym> _gyms;
        public CreateGymHandler(IBaseRepository<Gym> gyms)
        {
            _gyms = gyms;
        }

        public async Task<Gym> Handle(CreateGym request, CancellationToken cancellationToken)
        {
            var (id, name) = request;
            var gym = await _gyms.GetNullableById(id, cancellationToken);
            gym?.Update(name);
            gym ??= new Gym(name);
            return await _gyms.CreateOrUpdate(id, gym, cancellationToken);
        }

    }


}