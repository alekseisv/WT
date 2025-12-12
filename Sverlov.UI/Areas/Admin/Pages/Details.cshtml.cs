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
    public class DetailsModel : PageModel
    {
        private readonly Sverlov.UI.TempContext _context;

        public DetailsModel(Sverlov.UI.TempContext context)
        {
            _context = context;
        }

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
    }
}
