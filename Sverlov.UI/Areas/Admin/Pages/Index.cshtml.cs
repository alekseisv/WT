using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sverlov.Domain.Entities;
using Sverlov.UI;
using Sverlov.UI.Services;

namespace Sverlov.UI.Areas.Admin.Pages
{

    [Authorize(Policy ="admin")]
    public class IndexModel(IProductService productService) : PageModel
    {
        //private readonly Sverlov.UI.TempContext _context;

        //public IndexModel(IProductService productService)
        //{
        //    _context = context;
        //}

        public IList<Automobile> Automobile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Automobile = (await productService.GetProductListAsync(null)).Data;
        }
    }
}
