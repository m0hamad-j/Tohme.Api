using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tohme.Application.Command.DumbbellCommands;
using Tohme.Domain.Entities;

namespace Tohme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DumbbellController : ControllerBase
    {

        private readonly IMediator _mediator;
        public DumbbellController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<Dumbbell> Post(CreateDumbbell request)
            => await _mediator.Send(request);
    }
}
