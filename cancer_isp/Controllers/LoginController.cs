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
    public class LoginController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginController(IAuthService loginService, IUserService userService)
        {
            _authService = loginService;
            _userService = userService;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }

        [HttpGet]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitLogIn(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }

            var user = _authService.AuthUser(model);

            if (user == null)
            {
                //Add error handling
                return View("LogIn");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, UserRoleEnum.User.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp");
            }

            var user = _userService.GetUser(model.Username);

            if (user != null)
            {
                return View("SignUp");
            }

            _authService.RegisterUser(model);

            return View("LogIn");
        }
    }
}