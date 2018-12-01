using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistController : BaseController
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        [Route("artist/{id}")]
        public IActionResult Index(int id)
        {
            var artist = _artistService.GetArtist(id);
            var image = _artistService.GetArtistImage(id);
            var occupations = _artistService.GetOccupations();

            var artistViewModel = new ArtistViewModel();

            artistViewModel.Artist = artist;
            artistViewModel.Image = image;
            artistViewModel.Occupations = occupations;

            return View(artistViewModel);
        }

        [Route("artist/register")]
        public IActionResult Register()
        {
            //var artist = _artistService.GetArtist(id);
            //var image = _artistService.GetArtistImage(id);
            var occupations = _artistService.GetOccupations();

            var artistViewModel = new ArtistViewModel();

            //artistViewModel.Artist = artist;
            //artistViewModel.Image = image;
            artistViewModel.Occupations = occupations;

            return View(artistViewModel);
        }

        [Route("artist/list")]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterArtist(ArtistViewModel model)
        {
            return View();
        }

    }
}