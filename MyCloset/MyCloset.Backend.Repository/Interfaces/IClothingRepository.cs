using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Interfaces
{
    public interface IClothingRepository
    {
        public Task AddClothing(Clothing clothing, CancellationToken cancellationToken);
        public IQueryable<ClothingDTO> GetAllClothing();
        public Task<Clothing> GetClothingById(uint id, CancellationToken cancellationToken);
    }
}
