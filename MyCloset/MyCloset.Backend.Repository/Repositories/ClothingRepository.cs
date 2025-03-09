using Microsoft.EntityFrameworkCore;
using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyCloset.Backend.Infrastructure.Repositories
{
    public class ClothingRepository(MyClosetContext dbContext) : IClothingRepository
    {
        private readonly MyClosetContext _dbContext = dbContext;

        public async Task AddClothing(Clothing clothing)
        {
            await _dbContext.Clothes
               .AddAsync(clothing);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<ClothingDTO> GetAllClothing()
        {
            IQueryable<ClothingDTO>? clothes = _dbContext.Clothes.AsQueryable().Select(c => new ClothingDTO
            {

                Id = c.Id,
                Name = c.Name,
                Store = c.Store,
                Date = c.Date
            });

            return clothes.Any() ? clothes : Enumerable.Empty<ClothingDTO>().AsQueryable();
        }

        public async Task<Clothing> GetClothingById(uint id)
        {
            return await _dbContext.Clothes
                .AsQueryable<Clothing>()
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Invalid id. Clothing not found.");
        }
    }
}
