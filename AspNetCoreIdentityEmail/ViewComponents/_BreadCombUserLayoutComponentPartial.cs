using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents
{
    public class _BreadCombUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}