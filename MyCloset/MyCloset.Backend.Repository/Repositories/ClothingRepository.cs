using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Infrastructure.Repositories
{
    public class ClothingRepository(MyClosetContext dbContext, IImageRepository imageRepository) : IClothingRepository
    {
        private readonly MyClosetContext _dbContext = dbContext;
        private readonly IImageRepository _imageRepo = imageRepository;

        public async Task AddClothing(Clothing clothing, CancellationToken cancellationToken)
        {
            var addedClothing = await _dbContext.Clothes
               .AddAsync(clothing, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ClothingDTO?>> GetAllClothing()
        {
            return await _dbContext.Clothes.Select(c => new ClothingDTO
            {

                Id = c.Id,
                Name = c.Name,
                Store = c.Store,
                Prize = c.Prize,
                Date = c.Date,
                Images = c.Images
            }).ToListAsync();
        }

        public async Task<Clothing> GetClothingById(uint id, CancellationToken cancellationToken)
        {
            return await _dbContext.Clothes
                .AsQueryable<Clothing>()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new KeyNotFoundException("Invalid id. Clothing not found.");
        }
    }
}
