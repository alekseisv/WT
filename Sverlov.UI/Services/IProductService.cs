using Sverlov.Domain.Entities;
using Sverlov.Domain.Models;

namespace Sverlov.UI.Services
{
    public interface IProductService
    {

       
        public Task<ResponseData<List<Automobile>>> GetProductListAsync(string? theTransportType);
       
        public Task<ResponseData<Automobile>> GetByIdAsync(int id);
       
        public Task UpdateProductAsync(int id, Automobile product, IFormFile? formFile);
        
        public Task DeleteProductAsync(int id);
        
        public Task<ResponseData<Automobile>> CreateProductAsync(Automobile product, IFormFile? formFile);
    }
}
