using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Threading.Tasks;


namespace Project2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> UserMgr;
        private SignInManager<IdentityUser> SignInMgr;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await UserMgr.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInMgr.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await SignInMgr.PasswordSignInAsync(model.Email, model.Password,
                                        model.RememberMe, false);
                if (result.Succeeded)
                {

                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login attempt");
            }

            return View(model);
        }
        
    }
}
