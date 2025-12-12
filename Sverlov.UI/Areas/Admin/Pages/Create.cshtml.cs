using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sverlov.Domain.Entities;
using Sverlov.UI;

namespace Sverlov.UI.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Sverlov.UI.TempContext _context;

        public CreateModel(Sverlov.UI.TempContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TheTransportTypeId"] = new SelectList(_context.TheTransportTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Automobile Automobile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Automobiles.Add(Automobile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
