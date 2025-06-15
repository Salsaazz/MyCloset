using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Interfaces
{
    public interface IClothingRepository
    {
        public Task AddClothing(Clothing clothing, CancellationToken cancellationToken);
        public Task<IEnumerable<ClothingDTO?>> GetAllClothing(ClothingFilter? filters, string? sortColumn, string? sortOrder, int page, int pageSize);
        public Task<Clothing> GetClothingById(uint id, CancellationToken cancellationToken);
    }
}
