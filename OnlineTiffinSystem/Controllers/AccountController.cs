using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using OnlineTiffinSystem.Models;

using Project_Model.Models;

namespace OnlineTiffinSystem.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<IdentityUser> signinmanager;
        UserManager<IdentityUser> usermanager;

        public AccountController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> usermanager)
        {
            this.signinmanager = signInManager;
            this.usermanager = usermanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //akshadajagtap@gmail.com
        //Akshada123@
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel e)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = e.EmailAddress,
                    Email=e.EmailAddress,
                };

                var result = await usermanager.CreateAsync(user, e.Password);
                if(result.Succeeded)
                {
                    await signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(e);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signinmanager.PasswordSignInAsync
                (
                    model.EmailAddress,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false
                );

                if (result.Succeeded)
                {
                    var user = await usermanager.FindByEmailAsync(model.EmailAddress);

                    if (await usermanager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Menu", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signinmanager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

    }
}
