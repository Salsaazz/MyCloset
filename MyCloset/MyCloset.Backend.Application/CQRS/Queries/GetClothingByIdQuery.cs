using MediatR;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Queries
{
    public class GetClothingByIdQuery : IRequest<Clothing>
    {
        public uint Id { get; init; }
    }
    public class GetClothingByIdQueryHandler : IRequestHandler<GetClothingByIdQuery, Clothing>
    {
        private readonly IClothingRepository _clothingRepo;
        public GetClothingByIdQueryHandler(IClothingRepository clothingRepo) => _clothingRepo = clothingRepo;

        public async Task<Clothing> Handle(GetClothingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clothingRepo.GetClothingById(request.Id);
        }
    }
}
