using AspNetCoreIdentityEmail.Context;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.ViewComponents.MessageViewComponents
{
    public class _MessageCategoryListSidebarComponentPartial : ViewComponent
    {
        private readonly EmailContext _context;
        public _MessageCategoryListSidebarComponentPartial(EmailContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
    }
}
