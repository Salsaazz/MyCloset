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

        public IQueryable<Clothing> GetAllClothing()
        {
            return _dbContext.Clothes.AsQueryable();
        }
    }
}
