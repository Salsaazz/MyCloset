using MediatR;
using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Queries
{
    public class GetAllClothingQuery() : IRequest<IEnumerable<ClothingDTO?>>
    {
        public ClothingFilter? Filters { get; set; }
        public string? OrderColumn { get; set; }
        public string? OrderRow { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetAllClothingQueryHandler(IClothingRepository clothingRepo) : IRequestHandler<GetAllClothingQuery, IEnumerable<ClothingDTO?>>
    {
        private readonly IClothingRepository _clothingRepo = clothingRepo;

        public async Task<IEnumerable<ClothingDTO?>> Handle(GetAllClothingQuery request, CancellationToken cancellationToken)
        {
            return await _clothingRepo.GetAllClothing(request.Filters, request.OrderColumn?.ToLower(), request.OrderRow?.ToLower(),
                SetDefaultValueToPage(request.Page), SetDefaultValueToPageSize(request.PageSize));
        }

        private static int SetDefaultValueToPage(int? page) => page is null or < 1 ? 1 : page.Value;
        private static int SetDefaultValueToPageSize(int? pageSize) => pageSize is null or < 1 ? 10 : pageSize.Value;
    }
}
