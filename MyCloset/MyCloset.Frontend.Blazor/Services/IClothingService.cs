using MyCloset.Frontend.Blazor.Models;

namespace MyCloset.Frontend.Blazor.Services
{
    public interface IClothingService
    {
        public Task AddClothing(CreateClothingDTO clothing);
    }
}
