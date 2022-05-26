using Furniture_Management_MVC.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furniture_Management_MVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManger;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManger = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel registrationViewModel)
        {

            var user = await _userManger.FindByEmailAsync(registrationViewModel.Email);
            if (user != null)
            {
                ModelState.AddModelError("", $"User with email {registrationViewModel.Email} already exists!");
                return View(registrationViewModel);
            }
            else
            {

                var identityUser = new IdentityUser
                {
                    UserName = registrationViewModel.Email,
                    Email = registrationViewModel.Email
                };

                var result = await _userManger.CreateAsync(identityUser, registrationViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(registrationViewModel);

        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Furniture");
                }

                ModelState.AddModelError("", "Invalid credentials!");
            }

            return View(loginViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

        }

    }
}
