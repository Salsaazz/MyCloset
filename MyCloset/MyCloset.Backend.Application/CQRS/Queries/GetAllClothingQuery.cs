using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Application.Extensions;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Queries
{
    public class GetAllClothingQuery() : IRequest<IEnumerable<Clothing>>
    {
    }

    public class GetAllClothingQueryHandler : IRequestHandler<GetAllClothingQuery, IEnumerable<Clothing>>
    {
        private readonly IClothingRepository _clothingRepo;
        public GetAllClothingQueryHandler(IClothingRepository clothingRepo) => _clothingRepo = clothingRepo;

        public async Task<IEnumerable<Clothing>> Handle(GetAllClothingQuery request, CancellationToken cancellationToken)
        {
            return await _clothingRepo.GetAllClothing().ToListAsync(cancellationToken);
        }

        private void FormatClothingObj(Clothing clothing)
        {
            clothing.Name = clothing.Name.FormatString();

        }
    }
}
