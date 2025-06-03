using MyCloset.Frontend.Blazor.Models;
using System.Net.Http.Json;
using HttpClient = System.Net.Http.HttpClient;

namespace MyCloset.Frontend.Blazor.Services
{
    public class ClothingService : IClothingService
    {
        public async Task<HttpResponseMessage> AddClothing(CreateClothingDTO clothing)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7254");

            HttpResponseMessage response = await client.PostAsJsonAsync("/Clothing", clothing);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API Error ({(int)response.StatusCode}): {errorContent}");
            }

            return response;
        }

        public async Task<List<ClothingDTO?>> GetAllClothing()
        {
            using HttpClient client = new HttpClient();

            return await client.GetFromJsonAsync<List<ClothingDTO?>>(new Uri("https://localhost:7254/Clothing"));
        }
    }
}
