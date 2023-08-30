using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tohme.Application.Command.GymCommands;
using Tohme.Application.Dto;
using Tohme.Application.Queries;
using Tohme.Domain.Entities;

namespace Tohme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GymsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<GymDto> Post(CreateGym request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);

        [HttpPut("AddTrainer")]
        public async Task<Gym> AddTrainer(AddTrainerToGym request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);


        [HttpGet]
        public async Task<GymDto> GetById([FromQuery] DisplayGym request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}
