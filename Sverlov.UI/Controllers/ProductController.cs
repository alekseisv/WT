using Microsoft.AspNetCore.Mvc;
using Sverlov.UI.Services;

namespace Sverlov.UI.Controllers
{
    public class ProductController(ITheTransportTypeService theTransportTypeService,
        IProductService productService) : Controller
    {
        public async Task <IActionResult> Index([FromQuery]string? theTransportType,int pageNo=1)
        {

            ViewData["Categories"] = theTransportTypeService.GetTheTransportTypeListAsync().Result.Data;
            ViewData["CurrentCategory"] = String.IsNullOrEmpty(theTransportType) ?"Все": theTransportTypeService.GetTheTransportTypeListAsync()
                .Result.Data?
                .FirstOrDefault(c=>c.NormalizedName.Equals(theTransportType,StringComparison.OrdinalIgnoreCase))
                ?.Name ?? "Все";



            var result = await productService.GetProductListAsync(theTransportType);
            if (!result.Success) { return BadRequest(result.ErrorMessage); };
            return View(result.Data);
        }
    }
}
