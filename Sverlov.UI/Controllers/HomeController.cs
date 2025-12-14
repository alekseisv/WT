using Microsoft.AspNetCore.Mvc;

namespace Sverlov.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            
            
            ViewData["Greeting"] = "Лабораторная работа №2";
            return View();
        }
    }
}
