﻿using MediatR;

using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command
{
    public record DisplayGym(int gymId) : IRequest<Gym>;
    public class DisplayGymHandler : IRequestHandler<DisplayGym, Gym>
    {
        private readonly IBaseRepository<Gym> _gyms;
        public DisplayGymHandler(IBaseRepository<Gym> gyms)
        {
            _gyms = gyms;
        }

        public async Task<Gym> Handle(DisplayGym request, CancellationToken cancellationToken)
        {

            return await _gyms.GetById(request.gymId, cancellationToken);
        }
    } }
