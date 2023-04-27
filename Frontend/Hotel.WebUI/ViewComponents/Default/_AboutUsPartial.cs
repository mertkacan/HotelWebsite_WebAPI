using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
