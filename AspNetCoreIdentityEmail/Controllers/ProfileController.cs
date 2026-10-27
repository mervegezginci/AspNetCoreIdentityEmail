using AspNetCoreIdentityEmail.Entities;
using AspNetCoreIdentityEmail.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityEmail.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.ImageUrl = values.ImageUrl;
            userEditViewModel.City = values.City;
            userEditViewModel.UserName = values.UserName;
            userEditViewModel.Email = values.Email;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // Eğer yeni şifre girilmişse güncelleme yap
            if (!string.IsNullOrEmpty(model.Password))
            {
                if (model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError("", "Girdiğiniz yeni şifreler birbiriyle uyuşmuyor.");
                    return View(model);
                }

                if (!string.IsNullOrEmpty(model.Password)) user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            }

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.City = model.City;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.ImageUrl = model.ImageUrl;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("EditProfile");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(model);
            }
        }
    }
}
