using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using STO.Models;
using Microsoft.EntityFrameworkCore;
using STO.DataTransferObjects;

namespace STO.Controllers
{
    public class HomeController(StoContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            var userDto = new UserDto { ReturnUrl = HttpContext.Request.Query["ReturnUrl"].ToString() };
            return View(userDto);
        }

        public async Task<IActionResult> LoginPost(UserDto userDto)
        {
            if (!ModelState.IsValid) return View("Login", userDto);
            var dbUser = context.Users.FirstOrDefault(user =>
                user.Login == user.Login && user.Password == user.Password);

            if (dbUser == null)
            {
                ModelState.AddModelError("Password", "Invalid login or password");
                return View("Login", userDto);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>
                    {
                    new(ClaimTypes.Name, dbUser.Login),
                    new(ClaimTypes.Role, dbUser.Role)
                    }, CookieAuthenticationDefaults.AuthenticationScheme)));
            if (!string.IsNullOrWhiteSpace(userDto.ReturnUrl) && Url.IsLocalUrl(userDto.ReturnUrl))
                return Redirect(userDto.ReturnUrl);

            return RedirectToAction("Index");

           
        }
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
