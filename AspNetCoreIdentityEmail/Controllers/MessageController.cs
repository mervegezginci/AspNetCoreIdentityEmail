using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
