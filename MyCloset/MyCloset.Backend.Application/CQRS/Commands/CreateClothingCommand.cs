using MediatR;
using MyCloset.Backend.Application.Extensions;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Commands
{
    public class CreateClothingCommand : IRequest
    {
        public required CreateClothingDTO Clothing { get; init; }
    }

    public class CreateClothingCommandHandler(IClothingRepository clothingRepo) : IRequestHandler<CreateClothingCommand>
    {
        private readonly IClothingRepository _clothingRepo = clothingRepo;

        public async Task Handle(CreateClothingCommand command, CancellationToken cancellationToken)
        {
            Clothing newClothing = ConvertClothingToCreateClothingDTO(command.Clothing);

            FormatClothingObj(newClothing);
            await _clothingRepo.AddClothing(newClothing, cancellationToken);
        }

        private static void FormatClothingObj(Clothing clothing)
        {
            clothing.Name = clothing.Name
                .FormatString()
                .ToLower();
        }

        private static List<Image> ConvertUploadImageDTOsToImages(List<CreateImageDTO> imageDTOs)
        {
            List<Image> images = [];

            foreach (var imageDTO in imageDTOs)
            {
                if (imageDTO is not null)
                {
                    byte[] byteArray = Convert.FromBase64String(imageDTO.Data);
                    images.Add(new Image(byteArray, imageDTO.ContentType, imageDTO.FileName));
                }
            }
            return images;
        }

        private static Clothing ConvertClothingToCreateClothingDTO(CreateClothingDTO clothingDTO)
        {
            List<Image?> images = [];

            if (clothingDTO.Images.Count != 0)
                images = ConvertUploadImageDTOsToImages(clothingDTO.Images!)!;

            return new Clothing(
                clothingDTO.Name, clothingDTO.Colors, clothingDTO.Size,
                clothingDTO.Season, clothingDTO.Prize, clothingDTO.Aesthetic,
                clothingDTO.Type, clothingDTO.Date)
            { Images = images };
        }
    }

}
