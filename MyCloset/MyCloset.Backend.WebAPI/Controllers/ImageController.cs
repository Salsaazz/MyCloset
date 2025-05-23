using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCloset.Backend.Application.CQRS.Commands;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.WebAPI.Controllers.Interfaces;

namespace MyCloset.Backend.WebAPI.Controllers
{
    public class ImageController(IMediator mediator) : IApiController(mediator)
    {
        [HttpPost]
        public async Task<IActionResult> PostImages([FromQuery] uint clothingId, [FromBody] List<CreateImageDTO> images)
        {
            try
            {
                await _mediator.Send(new UploadImageCommand() { ClothingId = clothingId, Images = images });
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
