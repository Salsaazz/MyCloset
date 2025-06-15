using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCloset.Backend.Application.CQRS.Commands;
using MyCloset.Backend.Application.CQRS.Queries;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.WebAPI.Controllers.Interfaces;

namespace MyCloset.Backend.WebAPI.Controllers
{
    public class ClothingController(IMediator mediator) : IApiController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> GetAll([FromQuery] string? orderColumn, string? orderRow, int? page, int? pageSize, [FromBody] ClothingFilter clothingFilter)
            => Ok(await _mediator.Send(new GetAllClothingQuery()
            {
                Filters = clothingFilter,
                OrderColumn = orderColumn,
                OrderRow = orderRow,
                Page = page,
                PageSize = pageSize
            }
            ));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetClothingByIdQuery() { Id = uint.Parse(id) }));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("create")]
        public async Task<IActionResult> AddClothing([FromBody] CreateClothingDTO clothing)
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
