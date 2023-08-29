using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tohme.Application.Command;

using Tohme.Domain.Entities;

namespace Tohme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
            private readonly IMediator _mediator;
            public TrainerController(IMediator mediator)
            {
                _mediator = mediator;
            }
            [HttpPut]
            public async Task<Trainer> Post(CreateTrainer request)
                => await _mediator.Send(request);
        }
    }
