using MyCloset.Frontend.Blazor.Models;
using System.Net.Http.Json;

namespace MyCloset.Frontend.Blazor.Services
{
    public class ClothingService : IClothingService
    {
        public async Task AddClothing(CreateClothingDTO clothing)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7254");

            var result = await client.PostAsJsonAsync("/Clothing", clothing);
        }
    }
}
