using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sverlov.Domain.Entities;
using Sverlov.UI;

namespace Sverlov.UI.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Sverlov.UI.TempContext _context;

        public DeleteModel(Sverlov.UI.TempContext context)
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

            var automobile = await _context.Automobiles.FirstOrDefaultAsync(m => m.Id == id);

            if (automobile == null)
            {
                return NotFound();
            }
            else
            {
                Automobile = automobile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobile = await _context.Automobiles.FindAsync(id);
            if (automobile != null)
            {
                Automobile = automobile;
                _context.Automobiles.Remove(Automobile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
