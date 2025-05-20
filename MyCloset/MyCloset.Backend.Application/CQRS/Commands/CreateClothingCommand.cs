using MediatR;
using MyCloset.Backend.Application.Extensions;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Commands
{
    public class CreateClothingCommand : IRequest
    {
        public required Clothing Clothing { get; init; }
    }

    public class CreateClothingCommandHandler(IClothingRepository clothingRepo) : IRequestHandler<CreateClothingCommand>
    {
        private readonly IClothingRepository _clothingRepo = clothingRepo;

        public async Task Handle(CreateClothingCommand command, CancellationToken cancellationToken)
        {
            FormatClothingObj(command.Clothing);
            await _clothingRepo.AddClothing(command.Clothing, cancellationToken);
        }

        private static void FormatClothingObj(Clothing clothing)
        {
            clothing.Name = clothing.Name
                .FormatString()
                .ToLower();
        }
    }

}
