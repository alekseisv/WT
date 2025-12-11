using Microsoft.AspNetCore.Mvc;

namespace Sverlov.UI.ViewComponents;

public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();                      
    }
}
