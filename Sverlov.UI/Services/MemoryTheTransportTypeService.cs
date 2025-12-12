using Sverlov.Domain.Entities;
using Sverlov.Domain.Models;

namespace Sverlov.UI.Services
{
    public class MemoryTheTransportTypeService : ITheTransportTypeService
    {

        static readonly List<TheTransportType> theTransportTypes = [
            
            new TheTransportType {Id=1,Name="легковой автомобиль",NormalizedName="car"},
            new TheTransportType {Id=2,Name="грузовой автомобиль",NormalizedName="truck"},
            new TheTransportType {Id=3,Name="микро автобус",NormalizedName="minibus"},
            new TheTransportType {Id=4,Name="мотоцикл",NormalizedName="motorbike"}

            ];

        public Task<ResponseData<List<TheTransportType>>> GetTheTransportTypeListAsync()
        {
            var result = ResponseData<List<TheTransportType>>.OK(theTransportTypes);
            return Task.FromResult(result);
        }
    }
}
