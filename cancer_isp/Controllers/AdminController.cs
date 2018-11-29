using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(IUserService userService, IAuthService authService)
        {
        }

        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}