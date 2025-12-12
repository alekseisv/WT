using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sverlov.Domain.Entities;
using Sverlov.UI;

namespace Sverlov.UI.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly Sverlov.UI.TempContext _context;

        public EditModel(Sverlov.UI.TempContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Automobile Automobile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile =  await _context.Automobiles.FirstOrDefaultAsync(m => m.Id == id);
            if (automobile == null)
            {
                return NotFound();
            }
            Automobile = automobile;
           ViewData["TheTransportTypeId"] = new SelectList(_context.TheTransportTypes, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Automobile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomobileExists(Automobile.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutomobileExists(int id)
        {
            return _context.Automobiles.Any(e => e.Id == id);
        }
    }
}
