using MyCloset.Frontend.Blazor.Models;

namespace MyCloset.Frontend.Blazor.Services
{
    public interface IClothingService
    {
        public Task<HttpResponseMessage> AddClothing(CreateClothingDTO clothing);
    }
}
