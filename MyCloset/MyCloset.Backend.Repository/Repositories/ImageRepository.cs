using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Infrastructure.Repositories
{
    public class ImageRepository(MyClosetContext dbContext) : IImageRepository
    {
        private readonly MyClosetContext _dbContext = dbContext;

        public async Task<List<Image?>> GetImagesByClothingById(uint id, CancellationToken cancellationToken)
        {
            var images = await _dbContext.Images.Where(i => i.ClothingId == id).ToListAsync();

            if (images.Count < 0)
                throw new NullReferenceException("There are no images found.");
            else return images!;
        }

        public async Task UploadImagesByClothingId(List<Image> images, uint clothingId, CancellationToken cancellationToken)
        {
            var findClothing = await _dbContext.Clothes.FirstOrDefaultAsync(c => c.Id == clothingId, cancellationToken) ?? throw new NullReferenceException($"Clothing with id {clothingId} not found.");

            foreach (var image in images)
            {
                await _dbContext.Images.AddAsync(image, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
