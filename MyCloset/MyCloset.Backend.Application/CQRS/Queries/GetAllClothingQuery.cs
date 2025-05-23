using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Queries
{
    public class GetAllClothingQuery() : IRequest<IEnumerable<ClothingDTO>>
    {
    }

    public class GetAllClothingQueryHandler : IRequestHandler<GetAllClothingQuery, IEnumerable<ClothingDTO>>
    {
        private readonly IClothingRepository _clothingRepo;

        public GetAllClothingQueryHandler(IClothingRepository clothingRepo) => _clothingRepo = clothingRepo;

        public async Task<IEnumerable<ClothingDTO>> Handle(GetAllClothingQuery request, CancellationToken cancellationToken)
        {

            return await _clothingRepo.GetAllClothing().ToListAsync(cancellationToken);
        }
    }
}
