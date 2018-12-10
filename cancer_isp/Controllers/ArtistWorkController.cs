using System;
using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistWorkController : BaseController
    {
        private readonly IArtistWorkService _artistWorkService;
        private readonly IGenreService _genreService;
        private readonly IUserService _userService;
        private readonly IWorkRegistrationService _workRegistrationService;
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;

        public ArtistWorkController(IArtistWorkService artistWorkService, IGenreService genreService,
            IUserService userService, IWorkRegistrationService workRegistrationService,
            IStatisticsService statisticsService, IMapper mapper, IArtistService artistService)
        {
            _artistWorkService = artistWorkService;
            _genreService = genreService;
            _userService = userService;
            _workRegistrationService = workRegistrationService;
            _statisticsService = statisticsService;
            _mapper = mapper;
            _artistService = artistService;
        }

        [Route("work/{id}")]
        public IActionResult Index(int id)
        {
            var artistWork = _artistWorkService.GetArtistWork(id);
            var artists = _artistWorkService.GetArtistWorks(id);
            var ratings = _statisticsService.GetArtistWorkRatings(id);

            var artistsString = "";
            foreach (var item in artists)
            {
                artistsString += $"{item.Pseudonym}, ";
            }

            var artistWorkViewModel = new ArtistWorkViewModel
            {
                Artists = artistsString,
                ArtistWork = artistWork,
                ArtistWorkRatings = ratings
            };

            return View(artistWorkViewModel);
        }

        [Route("work/list")]
        public IActionResult List()
        {
            return View(new ArtistWorkFilter {Works = null});
        }

        [HttpGet]
        public IActionResult Filter(ArtistWorkFilter filter)
        {
            var result = new ArtistWorkFilter
            {
                Works = _artistWorkService.GetArtistWorks(filter.Name)
            };

            return View("List", result);
        }

        [Authorize]
        [Route("work/register")]
        public IActionResult Register()
        {
            var artistWorkRegistrationModel = new ArtistWorkRegistrationModel
            {
                Genres = _genreService.GetGenres()
            };

            return View(artistWorkRegistrationModel);
        }

        [HttpPost]
        public IActionResult RegisterWork(ArtistWorkRegistrationModel model)
        {
            var user = _userService.GetUser(Username);
            if (!ModelState.IsValid)
            {
                var genres = _genreService.GetGenres();
                model.Genres = genres;

                View("Register", model);
            }

            var valid = _workRegistrationService.CheckIfArtistExists(model.Artist);
            if (!valid)
            {
                var genres = _genreService.GetGenres();
                model.Genres = genres;

                View("Register", model);
            }

            var work = _mapper.Map<ArtistWork>(model);
            var artist = _artistService.GetArtist(model.Artist);

            work.FkImage = new Image
            {
                ImageDate = DateTime.Now,
                ImageUrl = model.ImageUrl
            };

            work.FkUserid = user.Id;
            work.CreationDate = DateTime.Now;

            var success = _workRegistrationService.RegisterWork(work, artist);
            if (success)
            {
                TempData["success"] = "Artist registration successful !";
            }

            return RedirectToAction("Register");
        }
    }
}