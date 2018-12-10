using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        public IActionResult Index()
        {
            return View("Index");
        }

        [Authorize(Roles = nameof(UserRoleEnum.Administrator))]
        public IActionResult ChangeRoles(AdminRolesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var result = _adminService.ChangePermissions(model.Id, model.Role);

            if (result)
            {
                TempData["success"] = "Change successful !";
            }

            return View("Index");
        }
    }
}