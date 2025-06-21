using MyCloset.Frontend.Blazor.Models;

namespace MyCloset.Frontend.Blazor.Services
{
    public interface IClothingService
    {
        public Task<HttpResponseMessage> AddClothing(CreateClothingDTO clothing);
        public Task<List<ClothingDTO?>> GetAllClothing(ClothingFilter? clothingFilter, string? orderColumn,
            string? orderRow, int? page, int? pageSize);
    }
}
