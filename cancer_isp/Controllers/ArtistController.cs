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

        [Route("artist/{id}")]
        public IActionResult Index(int id)
        {
            var artist = _artistService.GetArtist(id);

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}