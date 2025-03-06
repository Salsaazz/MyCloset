using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCloset.Backend.Application.CQRS.Queries;
using MyCloset.Backend.WebAPI.Controllers.Interfaces;

namespace MyCloset.Backend.WebAPI.Controllers
{
    public class ClothingController(IMediator mediator) : IApiController(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllClothingQuery()));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
