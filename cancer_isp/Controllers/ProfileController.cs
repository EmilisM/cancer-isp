using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [Route("profile")]
        public IActionResult Index()
        {
            var user = _userService.GetUser(Username);
            var result = new ProfileViewModel(user);

            return View(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(ProfileViewModel model)
        {
            var user = _userService.GetUser(Username);

            user.FkUserProfileInfo.FirstName = model.FirstName;
            user.FkUserProfileInfo.LastName = model.LastName;

            _userService.SetUser(user);

            return RedirectToAction("Index");
        }
    }
}