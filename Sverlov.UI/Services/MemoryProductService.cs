using Microsoft.AspNetCore.Http;
using Sverlov.Domain.Entities;
using Sverlov.Domain.Models;

namespace Sverlov.UI.Services
{
    public class MemoryProductService : IProductService
    {
        private readonly ITheTransportTypeService _theTransportTypeService;
        private List<Automobile> _automobiles = new();
        private List<TheTransportType> _theTransportTypes = new();

        public MemoryProductService(ITheTransportTypeService theTransportTypeService)
        {
            _theTransportTypeService = theTransportTypeService;

            // Получаем категории (типы транспорта)
            var response = _theTransportTypeService.GetTheTransportTypeListAsync()
 .GetAwaiter().GetResult();

            if (response.Success)
                _theTransportTypes = response.Data ?? new List<TheTransportType>();

            SetupData();
        }

        private void SetupData()
        {
            _automobiles = new List<Automobile>
 {
 new Automobile
 {
 Id = 1,
 Name = "MAZ",
 Description = "Грузовой автомобиль",
 LiftingCapacity = 20000,
 Image = "Images/Maz.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("truck"),
 TheTransportType = GetType("truck")
 },
 new Automobile
 {
 Id = 2,
 Name = "Автобус МАЗ",
 Description = "Пассажирский автобус",
 LiftingCapacity = 330,
 Image = "Images/MiniMaz.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("minibus")
 },
 new Automobile
 {
 Id = 3,
 Name = "Mercedes",
 Description = "Легковой автомобиль",
 LiftingCapacity = 500,
 Image = "Images/Mersedes.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("car")
 },
 new Automobile
 {
 Id = 4,
 Name = "Мотоцикл",
 Description = "Вааще что-то новенькое!!!",
 LiftingCapacity = 100,
 Image = "Images/Motobike.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("motorbike")
 },
 new Automobile
 {
 Id = 5,
 Name = "Volvo",
 Description = "Грузовой автомобиль",
 LiftingCapacity = 25000,
 Image = "Images/Volvo.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("truck")
 },
 new Automobile
 {
 Id = 6,
 Name = "BMW",
 Description = "Легковой автомобиль",
 LiftingCapacity = 300,
 Image = "Images/BMW.jfif",
 parsedDate = new DateOnly(2015, 10, 12),
 TheTransportTypeId = GetTypeId("car")
 }
 };
        }

        // Вспомогательные методы — чтобы не писать каждый раз Find(c => ...)
        private int GetTypeId(string normalizedName)
        {
            return _theTransportTypes
            .FirstOrDefault(t => t.NormalizedName.Equals(normalizedName, StringComparison.OrdinalIgnoreCase))
            ?.Id ?? 0;
        }

        private TheTransportType? GetType(string normalizedName)
        {
            return _theTransportTypes
            .FirstOrDefault(t => t.NormalizedName.Equals(normalizedName, StringComparison.OrdinalIgnoreCase));
        }

        public Task<ResponseData<List<Automobile>>> GetProductListAsync(string? theTransportType)
        {
            int? typeId = null;

            if (!string.IsNullOrEmpty(theTransportType))
            {
                typeId = GetTypeId(theTransportType);
                if (typeId == 0) typeId = null; // если не нашли — показываем все
            }

            var resultList = _automobiles
            .Where(a => typeId == null || a.TheTransportTypeId == typeId)
            .ToList();

            var response = resultList.Any()
            ? ResponseData<List<Automobile>>.OK(resultList)
            : ResponseData<List<Automobile>>.Error("Нет автомобилей в выбранной категории");

            return Task.FromResult(response);
        }

        // Остальные методы — пока не нужны для лабораторной
        public Task<ResponseData<Automobile>> GetByIdAsync(int id) => throw new NotImplementedException();
        public Task UpdateProductAsync(int id, Automobile automobile, IFormFile? formFile) => throw new NotImplementedException();
        public Task DeleteProductAsync(int id) => throw new NotImplementedException();
        public Task<ResponseData<Automobile>> CreateProductAsync(Automobile automobile, IFormFile? formFile) => throw new NotImplementedException();
    }
}