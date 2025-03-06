using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyCloset.Backend.WebAPI.Controllers.Interfaces
{
    [ApiController]
    [Route("[controller]")]
    public class IApiController(IMediator mediator) : ControllerBase
    {
        protected readonly IMediator _mediator = mediator;
    }
}
