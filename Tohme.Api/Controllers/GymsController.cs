using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tohme.Application.Command.GymCommands;
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
        [HttpPut]
        public async Task<Gym> Post(CreateGym request) 
            => await _mediator.Send(request);
    }
}
