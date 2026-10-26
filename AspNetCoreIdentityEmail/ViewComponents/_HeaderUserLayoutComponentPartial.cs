using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents
{
    public class _HeaderUserLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
