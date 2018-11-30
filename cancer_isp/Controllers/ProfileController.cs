using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [Route("profile")]
        public IActionResult Index()
        {
            var user = _userService.GetUser(Username);
            var result = _mapper.Map<ProfileViewModel>(user);

            return View(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(ProfileViewModel model)
        {
            var user = _userService.GetUser(Username);

            _mapper.Map(model, user);

            _userService.UpdateUser(user);

            return RedirectToAction("Index");
        }
    }
}