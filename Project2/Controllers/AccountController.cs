using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserMgr { get; set; }
        private SignInManager<AppUser> SignInMgr { get; set; }
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }


        public async Task<IActionResult> Register()
        {
            try 
            {
                ViewBag.Message = "Already registered";

                AppUser user = await UserMgr.FindByNameAsync("TestUser");
                if (user==null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser";
                    user.Email = "TestUser@test.com";

                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was successfully created";
                }
            }catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }
        
    }
}
