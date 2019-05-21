using System;
using System.Linq;
using cancer_isp_2.Database;
using cancer_isp_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace cancer_isp_2.Controllers
{
    [Route("api/login")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public LoginController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("page")]
        public IActionResult openLogin(  )
		{
            return Ok();
        }

        [HttpGet]
        [Route("password/reset")]
        public IActionResult sendPasswordEmailReset(string email)
		{
            return Ok(email);
		}

        [HttpGet]
        [Route("login")]
        public IActionResult login()
        {
            authenticateUser();
            return Ok(CookieAuthenticationDefaults.AuthenticationScheme);
		}
		

		private void authenticateUser()
		{
            var user = User.Identity.IsAuthenticated;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult openRegister(  )
		{
            return Ok();
		}

        private bool validateRegistrationData()
		{
            return true;
		}

        [HttpPost]
        [Route("register/new")]
        public IActionResult register(User user)
		{
            if (!ModelState.IsValid)
            {
                return Ok("SignUp");
            }
            var valid = validateEmailAdress(user.Email);

            if (!valid)
            {
                ModelState.AddModelError("Error", "Email is already taken");
                return Ok("SignUp");
            }

            if (user != null)
            {
                ModelState.AddModelError("Error", "Username is already taken");
                return Ok("SignUp");
            }

            var success = validateRegistrationData();

            if (success)
            {
                var TempData = "Registration successful !";
            }
            return Ok();
		}

        [HttpPost]
        [Route("password/remind")]
        public IActionResult remindPassword(User user)
		{
            if (!ModelState.IsValid)
            {
                return Ok("LogIn");
            }

            if (user.Email == null)
            {
                ModelState.AddModelError("Error", "Email is not specified");
                return Ok("LogIn");
            }

            var valid = validateEmailAdress(user.Email);

            if (!valid)
            {
                sendPasswordEmailReset(user.Email);
            }

            var TempData = "Email remainder sent !";

            return Ok("LogIn");
        }
		
		private bool validateEmailAdress(string email)
		{
            if(email != null)
            return true;

            return false;
		}
		
		public void validateLoginData(User user )
		{
            validateUserPassword(user.Username,user.PasswordHash);
		}


        public IActionResult redirectToPasswordReset(  )
		{
            return Ok();
		}

        [HttpPost]
        [Route("password/reset")]
        public IActionResult passwordReset(int userId)
		{
            return Ok();
        }
		
		private bool validateUserPassword(string username, string pass)
		{
            var users = _context.User.Where(user => user.PasswordHash.Equals(pass) && user.Username.Equals(username)).First();

            if (users != null) return true;
            return false;
		}
		
	}
	
}
