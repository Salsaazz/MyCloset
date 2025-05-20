using MediatR;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Commands
{
    public class UploadImageCommand : IRequest
    {
        public required List<UploadImageDTO> Images { get; set; }
        public required uint ClothingId { get; set; }
    }

    public class UploadImageCommandHandler(IImageRepository imageRepository)
    {
        private readonly IImageRepository _imageRepo = imageRepository;

        public async Task Handle(UploadImageCommand command, CancellationToken cancellationToken)
        {
            if (command.Images.Count > 0)
                await _imageRepo.UploadImagesByClothingId(command.Images, command.ClothingId, cancellationToken);

            else throw new ArgumentNullException("There are no images to upload.");
        }
    }
}
