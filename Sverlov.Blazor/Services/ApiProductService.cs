using Sverlov.API.Models;
using Sverlov.Domain;
using Sverlov.Domain.Entities;
using System.Net.Http.Json;
using System.Web;

namespace Sverlov.Blazor.Services
{
    public class ApiProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        // Свойства из интерфейса
        public int CurrentPage { get; private set; } = 1;
        public int TotalPages { get; private set; } = 1;
        public List<Automobile> Products { get; private set; } = new();

        public List<Automobile> Automobiles => throw new NotImplementedException();

        // Событие для уведомления компонентов (Pager и AutomobileList)
        public event Action? ListChanged;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProducts(int page = 1, string? category = null)
        {
            CurrentPage = page;

            try
            {
                // Путь без дубликата — BaseAddress уже содержит хост
                string url = "api/Automobiles";  // С большой A, как в контроллере

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadFromJsonAsync<ResponseData<List<Automobile>>>();
                    Products = responseData?.Data ?? new List<Automobile>();  // ResponseData имеет поле Data
                }
                else
                {
                    Products = new List<Automobile>();
                    Console.WriteLine($"Ошибка HTTP: {response.StatusCode}");
                }

                TotalPages = Products.Any() ? 1 : 0;  // Пока без пагинации
                ListChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Products = new List<Automobile>();
                TotalPages = 1;
                ListChanged?.Invoke();
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }
    }
}