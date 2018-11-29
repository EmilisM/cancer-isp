using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(IUserService userService, IAuthService authService)
        {
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}