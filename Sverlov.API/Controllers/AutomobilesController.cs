using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sverlov.API.Data;
using Sverlov.API.Models;
using Sverlov.Domain.Entities;

namespace Sverlov.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobilesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutomobilesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Automobiles?category=trucks
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Automobile>>>> GetAutomobiles(string? category)
        {
            IQueryable<Automobile> query = _context.Automodiles.Include(a => a.TheTransportType);

            if (!string.IsNullOrEmpty(category))
            {
                // Переносим логику фильтрации на клиентскую сторону (ToListAsync сначала)
                var allData = await query.ToListAsync();
                var filtered = allData.Where(a => a.TheTransportType != null &&
                a.TheTransportType.NormalizedName.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

                if (!filtered.Any())
                {
                    return Ok(ResponseData<List<Automobile>>.Error("Нет автомобилей в выбранной категории"));
                }

                return Ok(ResponseData<List<Automobile>>.OK(filtered));
            }

            // Если категория не указана — возвращаем все с Include
            var data = await query.ToListAsync();
            return Ok(ResponseData<List<Automobile>>.OK(data));
        }



        // GET: api/Automobiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automobile>> GetAutomobile(int id)
        {
            var automobile = await _context.Automodiles.FindAsync(id);

            if (automobile == null)
            {
                return NotFound();
            }

            return automobile;
        }

        // PUT: api/Automobiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomobile(int id, Automobile automobile)
        {
            if (id != automobile.Id)
            {
                return BadRequest();
            }

            _context.Entry(automobile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Automobiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Automobile>> PostAutomobile(Automobile automobile)
        {
            _context.Automodiles.Add(automobile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomobile", new { id = automobile.Id }, automobile);
        }

        // DELETE: api/Automobiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutomobile(int id)
        {
            var automobile = await _context.Automodiles.FindAsync(id);
            if (automobile == null)
            {
                return NotFound();
            }

            _context.Automodiles.Remove(automobile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutomobileExists(int id)
        {
            return _context.Automodiles.Any(e => e.Id == id);
        }
    }
}
