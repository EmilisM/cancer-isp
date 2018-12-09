using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStatisticsService _statisticsService;

        public ProfileController(IUserService userService, IMapper mapper, IStatisticsService statisticsService)
        {
            _userService = userService;
            _mapper = mapper;
            _statisticsService = statisticsService;
        }

        [Authorize]
        [Route("profile")]
        public IActionResult Index()
        {
            var user = _userService.GetUser(Username);
            var result = _mapper.Map<ProfileViewModel>(user);
            var userRatings = _statisticsService.GetUserRatings(user.Id);
            result.UserRatings = userRatings;

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