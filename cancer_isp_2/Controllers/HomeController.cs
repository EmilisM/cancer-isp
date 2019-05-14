using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Controllers
{
    [Route("api/home")]
    [Produces("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public HomeController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("top")]
        public IActionResult GetNewSongs()
        {
            var songs = _context.Song
                .Include(song => song.Ratings)
                .Include(song => song.Image)
                .Include(song => song.Artists)
                .ThenInclude(song => song.Artist)
                .Select(song => new {Song = song, AverageRating = song.Ratings.Average(rating => rating.Points)})
                .ToList();

            var orderedSongs = songs.OrderBy(song => song.AverageRating).Take(20).ToList();

            return Ok(orderedSongs);
        }
    }
}