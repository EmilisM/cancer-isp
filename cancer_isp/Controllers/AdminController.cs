using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AdminController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("admin")]
        public async Task<IActionResult> LogIn()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            var user = _authService.AuthUser(model, true);

            if (user == null)
            {
                return View("Login");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, UserRoleEnum.Administrator.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return View("Index");
        }
    }
}