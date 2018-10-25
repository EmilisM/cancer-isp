using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class LoginController : Controller
    {
        [Route("login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}