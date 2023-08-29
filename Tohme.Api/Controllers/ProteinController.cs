using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tohme.Application.Command;

using Tohme.Domain.Entities;

namespace Tohme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProteinController : ControllerBase
    {

            private readonly IMediator _mediator;
            public ProteinController(IMediator mediator)
            {
                _mediator = mediator;
            }
            [HttpPut]
            public async Task<Protein> Post(CreateProtein request)
                => await _mediator.Send(request);
        }
    }
