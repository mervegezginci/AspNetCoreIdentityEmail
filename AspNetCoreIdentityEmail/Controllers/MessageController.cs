using AspNetCoreIdentityEmail.Context;
using AspNetCoreIdentityEmail.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityEmail.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;

        public MessageController(EmailContext context)
        {
            _context = context;
        }

        public IActionResult Inbox()
        {
            var values = _context.Messages
                .Include(x => x.Category)
                .Where(x => x.ReceiverEmail == "ymlenovo19@gmail.com")
                .OrderByDescending(x => x.SendDate)
                .ToList();
            return View(values);
        }

        public IActionResult Sendbox()
        {
            var values = _context.Messages
                .Include(x => x.Category)
                .Where(x => x.SenderEmail == "ymlenovo19@gmail.com")
                .OrderByDescending(x => x.SendDate)
                .ToList();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var value = _context.Messages
                .Include(x => x.Category)
                .FirstOrDefault(x => x.MessageId == id);

            if (value != null && !value.IsRead)
            {
                value.IsRead = true;
                _context.SaveChanges();
            }

            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            List<SelectListItem> categories = (from x in _context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SenderEmail = "ymlenovo19@gmail.com";
            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Sendbox");
        }

        public IActionResult GetMessageListByCategory(int id)
        {
            var values = _context.Messages
                .Include(x => x.Category)
                .Where(x => x.CategoryId == id && x.ReceiverEmail == "ymlenovo19@gmail.com")
                .OrderByDescending(x => x.SendDate)
                .ToList();
            return View("Inbox", values);
        }
    }
}
