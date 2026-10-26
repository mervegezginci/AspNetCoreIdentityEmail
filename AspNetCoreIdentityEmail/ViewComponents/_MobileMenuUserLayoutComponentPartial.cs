using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents
{
    public class _MobileMenuUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
