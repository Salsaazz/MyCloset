using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCloset.Backend.Application.CQRS.Commands;
using MyCloset.Backend.Application.CQRS.Queries;
using MyCloset.Backend.Domain.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddClothing([FromBody] Clothing clothing)
        {
            try
            {
                await _mediator.Send(new CreateClothingCommand() { Clothing = clothing });
                return Created();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
