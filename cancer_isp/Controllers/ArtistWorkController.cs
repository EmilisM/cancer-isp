using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistWorkController : BaseController
    {
        private readonly IArtistWorkService _artistWorkService;

        public ArtistWorkController(IArtistWorkService artistWorkService)
        {
            _artistWorkService = artistWorkService;
        }

        [Route("work/{id}")]
        public IActionResult Index(int id)
        {
            var artistWork = _artistWorkService.GetArtistWork(id);
            var artists = _artistWorkService.GetArtistWorkCreators(id);

            var artistsString = "";
            foreach (var item in artists)
            {
                artistsString += $"{item.Pseudonym}, ";
            }

            var artistWorkViewModel = new ArtistWorkViewModel
            {
                Artists = artistsString,
                ArtistWork = artistWork
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