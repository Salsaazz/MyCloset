using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Infrastructure.Interfaces
{
    public interface IClothingRepository
    {
        public Task AddClothing(Clothing clothing);
        public IQueryable<ClothingDTO> GetAllClothing();
        public Task<Clothing> GetClothingById(uint id);
    }
}
