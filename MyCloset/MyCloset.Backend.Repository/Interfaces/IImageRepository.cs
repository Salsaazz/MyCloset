using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Interfaces
{
    public interface IImageRepository
    {
        public Task UploadImagesByClothingId(List<Image> images, uint clothingId, CancellationToken cancellationToken);
        public Task<List<Image?>> GetImagesByClothingById(uint id, CancellationToken cancellationToken);
    }
}
