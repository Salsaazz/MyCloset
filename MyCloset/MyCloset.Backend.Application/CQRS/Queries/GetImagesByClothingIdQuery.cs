using MediatR;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Application.CQRS.Queries
{
    public class GetImagesByClothingIdQuery() : IRequest<List<Image?>>
    {
        public uint ClothingId { get; set; }
    }

    public class GetImagesByClothingIdQueryHandler : IRequestHandler<GetImagesByClothingIdQuery, List<Image?>>
    {
        private readonly IImageRepository _imageRepo;
        public GetImagesByClothingIdQueryHandler(IImageRepository imageRepo) => _imageRepo = imageRepo;

        public async Task<List<Image?>> Handle(GetImagesByClothingIdQuery request, CancellationToken cancellationToken)
        {
            return await _imageRepo.GetImagesByClothingById(request.ClothingId, cancellationToken);
        }
    }
}
