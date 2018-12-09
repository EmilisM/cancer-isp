using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cancer_isp.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ISmtpService _smtpService;

        public LoginController(IAuthService loginService, IUserService userService, ISmtpService smtpService)
        {
            _authService = loginService;
            _userService = userService;
            _smtpService = smtpService;
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
        public async Task<IActionResult> SubmitLogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }

            if (model.Username == null)
            {
                ModelState.AddModelError("Error", "Username is not specified");
                return View("LogIn");
            }

            if (model.Password == null)
            {
                ModelState.AddModelError("Error", "Password is not specified");
                return View("LogIn");
            }

            var user = _authService.AuthUser(model);

            if (user == null)
            {
                ModelState.AddModelError("Error", "User not found");
                return View("LogIn");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, user.UserRole.Name.ToString())
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
            var valid = _userService.IsEmailValid(model.Email);

            if (!valid)
            {
                ModelState.AddModelError("Error", "Email is already taken");
                return View("SignUp");
            }

            if (user != null)
            {
                ModelState.AddModelError("Error", "Username is already taken");
                return View("SignUp");
            }

            var success = _authService.RegisterUser(model);

            if (success)
            {
                TempData["success"] = "Registration successful !";
            }

            return View("SignUp");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RemindPassword(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LogIn");
            }

            if (model.Email == null)
            {
                ModelState.AddModelError("Error", "Email is not specified");
                return View("LogIn");
            }

            var valid = _userService.IsEmailValid(model.Email);

            if (!valid)
            {
                _smtpService.SendPasswordReminder(model.Email);
            }

            TempData["success"] = "Email remainder sent !";

            return View("LogIn");
        }
    }
}