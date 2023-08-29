using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tohme.Application.Command;

using Tohme.Domain.Entities;

namespace Tohme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {

            private readonly IMediator _mediator;
            public TraineeController(IMediator mediator)
            {
                _mediator = mediator;
            }
            [HttpPut]
            public async Task<Trainee> Post(CreateTrainee request)
                => await _mediator.Send(request);
        }
    }

