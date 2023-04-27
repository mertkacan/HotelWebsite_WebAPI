using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default
{
    public class _NavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
