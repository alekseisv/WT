using Microsoft.AspNetCore.Mvc;
using Sverlov.Domain.Entities;
using Sverlov.UI.Services;
using System.Net;

namespace Sverlov.UI.Controllers
{
    public class ProductController(ITheTransportTypeService theTransportTypeService,
        IProductService productService) : Controller
    {

        public async Task<IActionResult> Index([FromQuery] string? theTransportType, int pageNo = 1)
        {
            var categoriesResponse = await theTransportTypeService.GetTheTransportTypeListAsync();

            var categories = categoriesResponse.Success ? categoriesResponse.Data ?? new List<TheTransportType>() : new List<TheTransportType>();

            ViewData["Categories"] = categories;

            ViewData["CurrentCategory"] = "Все";
            if (!string.IsNullOrEmpty(theTransportType))
            {
                var cat = categories.FirstOrDefault(c => c.NormalizedName.Equals(theTransportType, StringComparison.OrdinalIgnoreCase));
                if (cat != null) ViewData["CurrentCategory"] = cat.Name;
            }

            var productsResponse = await productService.GetProductListAsync(theTransportType);

            var products = productsResponse.Success ? productsResponse.Data ?? new List<Automobile>() : new List<Automobile>();

            return View(products);
        }


        //public async Task<IActionResult> Index([FromQuery] string? theTransportType, int pageNo = 1)
        //{

        //    ViewData["Categories"] = theTransportTypeService.GetTheTransportTypeListAsync().Result.Data;
        //    ViewData["CurrentCategory"] = String.IsNullOrEmpty(theTransportType) ? "Все" : theTransportTypeService.GetTheTransportTypeListAsync()
        //        .Result.Data?
        //        .FirstOrDefault(c => c.NormalizedName.Equals(theTransportType, StringComparison.OrdinalIgnoreCase))
        //        ?.Name ?? "Все";



        //    var result = await productService.GetProductListAsync(theTransportType);
        //    if (!result.Success) { return BadRequest(result.ErrorMessage); }
        //    ;
        //    return View(result.Data);
        //}
        //public async Task<IActionResult> Index([FromQuery] string? theTransportType, int pageNo = 1)
        //{
        //    // Получаем категории асинхронно
        //    var categoriesResponse = await theTransportTypeService.GetTheTransportTypeListAsync();

        //    // Защищаем от null и ошибок
        //    var categories = categoriesResponse.Success && categoriesResponse.Data != null
        // ? categoriesResponse.Data
        // : new List<TheTransportType>();

        //    ViewData["Categories"] = categories;

        //    // Текущая категория для заголовка меню
        //    string currentCategory = "Все";
        //    if (!string.IsNullOrEmpty(theTransportType) && categories.Any())
        //    {
        //        var cat = categories.FirstOrDefault(c =>
        //        c.NormalizedName.Equals(theTransportType, StringComparison.OrdinalIgnoreCase));
        //        if (cat != null)
        //        {
        //            currentCategory = cat.Name;
        //        }
        //    }
        //    ViewData["CurrentCategory"] = currentCategory;

        //    // Получаем автомобили
        //    var result = await productService.GetProductListAsync(theTransportType);

        //    if (result.Success && result.Data != null)
        //    {
        //        return View(result.Data);
        //    }
        //    else
        //    {
        //        // Если ошибка — показываем пустой список
        //        return View(new List<Automobile>());
        //    }
        //}
    }
}
