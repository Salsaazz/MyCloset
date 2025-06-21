using MyCloset.Frontend.Blazor.Models;
using System.Net.Http.Json;
using HttpClient = System.Net.Http.HttpClient;

namespace MyCloset.Frontend.Blazor.Services
{
    public class ClothingService(IHttpClientFactory httpClientFactory) : IClothingService
    {
        private readonly HttpClient client = httpClientFactory.CreateClient();

        public async Task<HttpResponseMessage> AddClothing(CreateClothingDTO clothing)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync("Clothing/create", clothing);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API Error ({(int)response.StatusCode}): {errorContent}");
            }

            return response;
        }

        public async Task<List<ClothingDTO?>> GetAllClothing(ClothingFilter? clothingFilter, string? orderColumn, string? orderRow,
            int? page, int? pageSize)
        {
            var queryParams = ApplyQueryParameters(orderColumn, orderRow, page, pageSize);

            var uri = "/Clothing";
            if (queryParams.Count > 0)
                uri += "?" + string.Join("&", queryParams);

            if (clothingFilter is not null)
            {
                var response = await client.PostAsJsonAsync(uri, clothingFilter);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<ClothingDTO?>>();
            }

            return await client.GetFromJsonAsync<List<ClothingDTO?>>(uri);
        }

        private List<string> ApplyQueryParameters(string? orderColumn, string? orderRow,
            int? page, int? pageSize)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(orderColumn))
                queryParams.Add($"orderColumn={Uri.EscapeDataString(orderColumn)}");

            if (!string.IsNullOrWhiteSpace(orderRow))
                queryParams.Add($"orderRow={Uri.EscapeDataString(orderRow)}");

            if (page.HasValue)
                queryParams.Add($"page={page.Value}");

            if (pageSize.HasValue)
                queryParams.Add($"pageSize={pageSize.Value}");

            return queryParams;
        }
    }
}
