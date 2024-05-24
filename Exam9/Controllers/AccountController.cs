using Exam9.Models;
using Exam9.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Exam9.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            AppUser user1 = await _userManager.FindByNameAsync(vm.User);
            if (user1 == null)
            {
                user1 = await _userManager.FindByEmailAsync(vm.User);
                if (user1 == null)
                {
                    ModelState.AddModelError("", "İstifadəçi adı yalnışdır");
                }
                return View(vm);
            }
            var ab = await _signInManager.PasswordSignInAsync(user1, vm.Password, true, true);
            if (ab.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
