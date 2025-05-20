using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Infrastructure.Repositories
{
    public class ImageRepository(MyClosetContext dbContext, IClothingRepository clothingRepo) : IImageRepository
    {
        private readonly MyClosetContext _dbContext = dbContext;
        private readonly IClothingRepository _clothingRepo = clothingRepo;

        public async Task<List<Image?>> GetImagesByClothingById(uint id, CancellationToken cancellationToken)
        {
            var clothing = await _clothingRepo.GetClothingById(id, cancellationToken);
            List<Image?> images = clothing.Images;

            if (images.Count < 0)
                throw new NullReferenceException("There are no images found.");
            else return images!;
        }

        public async Task UploadImagesByClothingId(List<IFormFile> files, uint clothingId, CancellationToken cancellationToken)
        {
            var findClothing = await _dbContext.Clothes.FirstOrDefaultAsync(c => c.Id == clothingId, cancellationToken) ?? throw new NullReferenceException($"Clothing with id {clothingId} not found.");


            using var ms = new MemoryStream();
            foreach (var file in files)
            {
                await file.CopyToAsync(ms, cancellationToken);
                var image = new Image(ms.ToArray(), file.ContentType, file.FileName)
                { Clothing = findClothing, ClothingId = findClothing.Id };

                findClothing.Images.Add(image);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UploadImagesByClothingId(List<UploadImageDTO> images, uint clothingId, CancellationToken cancellationToken)
        {
            var findClothing = await _dbContext.Clothes.FirstOrDefaultAsync(c => c.Id == clothingId, cancellationToken) ?? throw new NullReferenceException($"Clothing with id {clothingId} not found.");

            foreach (var image in images)
            {
                var newImage = new Image(Convert.FromBase64String(image.Data), image.ContentType, image.FileName)
                { Clothing = findClothing, ClothingId = findClothing.Id };

                findClothing.Images.Add(newImage);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
