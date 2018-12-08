using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistWorkController : BaseController
    {
        private readonly IArtistWorkService _artistWorkService;
        private readonly IStatisticsService _statisticsService;

        public ArtistWorkController(IArtistWorkService artistWorkService, IStatisticsService statisticsService)
        {
            _artistWorkService = artistWorkService;
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

        [Authorize]
        [Route("work/register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}