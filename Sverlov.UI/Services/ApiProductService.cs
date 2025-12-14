using Sverlov.API.Models;
using Sverlov.Domain.Entities;
using Sverlov.UI.Services;
using System.Net.Http.Json;
using Sverlov.UI.Services;

namespace Sverlov.UI.Services // или ваш namespace
{
    public class ApiProductService : IProductService // ваш интерфейс для объектов
    {
        private readonly HttpClient _httpClient;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ResponseData<Automobile>> CreateProductAsync(Automobile product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Automobile>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<List<Automobile>>> GetProductListAsync(string? category = null)
        {
            var query = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(category))
                query["category"] = category;

            var queryString = QueryString.Create(query);
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + queryString.Value);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content
                    .ReadFromJsonAsync<ResponseData<List<Automobile>>>();

                return result ?? ResponseData<List<Automobile>>.Error("Пустой ответ от API");
            }

            return ResponseData<List<Automobile>>.Error($"Ошибка API: {response.StatusCode}");
        }

        public Task UpdateProductAsync(int id, Automobile product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        // Другие методы (Create, Update и т.д.) добавите позже
    }
}