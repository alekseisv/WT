using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sverlov.API.Data;
using Sverlov.API.Models;
using Sverlov.Domain.Entities; // TransportType или TheTransportType

namespace Sverlov.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransportTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TransportTypes
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<TheTransportType>>>> GetTransportTypes()
        {
            var data = await _context.TheTransportTypes.ToListAsync();

            return Ok(ResponseData<List<TheTransportType>>.OK(data));
        }

        // Если нужен GetById (для безопасности)
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseData<TheTransportType>>> GetTransportType(int id)
        {
            var item = await _context.TheTransportTypes.FindAsync(id);
            if (item == null)
            {
                return NotFound(ResponseData<TheTransportType>.Error("Не найдено"));
            }

            return Ok(ResponseData<TheTransportType>.OK(item));
        }
    }
}