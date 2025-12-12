using Sverlov.Domain.Entities;
using Sverlov.Domain.Models;

namespace Sverlov.UI.Services
{
    public interface ITheTransportTypeService
    {
        /// <summary>
        /// Получение списка всех категорий
        /// </summary>
        /// <returns></returns>
        public Task<ResponseData<List<TheTransportType>>> GetTheTransportTypeListAsync();
    }
}
