using Sverlov.API.Models;         // ResponseData<T>
using Sverlov.Domain.Entities;     // TransportType
using System.Net.Http.Json;

namespace Sverlov.UI.Services
{
    public class ApiTheTransportTypeService : ITheTransportTypeService
    {
        private readonly HttpClient _httpClient;

        public ApiTheTransportTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseData<List<TheTransportType>>> GetTheTransportTypeListAsync()
        {
            var response = await _httpClient.GetAsync(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseData<List<TheTransportType>>>()
                ?? ResponseData<List<TheTransportType>>.Error("Пустой ответ");
            }

            return ResponseData<List<TheTransportType>>.Error($"Ошибка: {response.StatusCode}");
        }

        // Если вызывается — простая реализация
        public async Task<ResponseData<TheTransportType>> GetTheTransportTypeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseData<TheTransportType>>()
                ?? ResponseData<TheTransportType>.Error("Не найдено");
            }
            return ResponseData<TheTransportType>.Error($"Ошибка: {response.StatusCode}");
        }

        // Заглушки для остальных
        public Task CreateTheTransportTypeAsync(TheTransportType type) => Task.CompletedTask;
        public Task UpdateTheTransportTypeAsync(TheTransportType type) => Task.CompletedTask;
        public Task DeleteTheTransportTypeAsync(int id) => Task.CompletedTask;
    }
}