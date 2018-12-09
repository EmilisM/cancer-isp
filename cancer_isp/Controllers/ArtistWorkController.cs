using cancer_isp.Models;
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

        public ArtistWorkController(IArtistWorkService artistWorkService, IGenreService genreService, IUserService userService, IWorkRegistrationService workRegistrationService, IStatisticsService statisticsService)
        {
            _artistWorkService = artistWorkService;
            _genreService = genreService;
            _userService = userService;
            _workRegistrationService = workRegistrationService;
            _statisticsService = statisticsService;
        }

        [Route("work/{id}")]
        public IActionResult Index(int id)
        {
            var artistWork = _artistWorkService.GetArtistWork(id);
            var artists = _artistWorkService.GetArtistWorkCreators(id);
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
            
            return View();
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
          /*  var valid = _workRegistrationService.CheckArtist(model);
            if (!valid)
            {
                ModelState.AddModelError("Error", "Specified artist is not registered yet");
                return View("List");
            }*/
            _workRegistrationService.RegisterWork(model, user);
            return View("List");
        }
    }
}