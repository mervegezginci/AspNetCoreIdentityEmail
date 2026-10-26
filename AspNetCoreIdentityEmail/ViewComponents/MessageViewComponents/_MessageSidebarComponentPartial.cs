using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents.MessageViewComponents
{
    public class _MessageSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
