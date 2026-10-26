using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents
{
    public class _NavbarUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
