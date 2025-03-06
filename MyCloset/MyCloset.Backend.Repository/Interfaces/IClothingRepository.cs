using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Interfaces
{
    public interface IClothingRepository
    {
        public Task AddClothing(Clothing clothing);
        public IQueryable<Clothing> GetAllClothing();
    }
}
