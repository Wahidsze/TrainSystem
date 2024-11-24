using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainSystem.Database;
using TrainSystem.Models.ModelViews;
using TrainSystem.Services;
using static System.Net.WebRequestMethods;

namespace TrainSystem.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext _context { get; set; }
        private IUserService _service { get; set; }
        public AccountController(ApplicationContext context) 
        {
            _context = context;
            _service = new UserService(_context);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Login(model);
                if (result != null)
                {
                    await Authenticate(result);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Register(model);
                if (result != null)
                {
                    await Authenticate(result);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(ClaimsIdentity id)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
