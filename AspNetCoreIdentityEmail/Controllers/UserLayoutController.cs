using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
