using System;
using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Controllers
{
    [Route("api/song")]
    [Produces("application/json")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public SongController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("new")]
        public IActionResult GetNewSongs()
        {
            var songs = _context.Song
                .Include(song => song.Artists)
                .ThenInclude(song => song.Artist)
                .Where(song =>
                    song.ReleaseDate.HasValue && song.ReleaseDate.Value.Month == DateTime.Now.Month);

            return Ok(songs);
        }

        [HttpGet]
        [Route("{songId}")]
        public IActionResult GetSong(int songId)
        {
            var song = _context.Song
                .Include(item => item.Artists)
                .ThenInclude(item => item.Artist)
                .Include(item => item.Ratings)
                .ThenInclude(item => item.User)
                .Include(item => item.Genres)
                .ThenInclude(item => item.Genre)
                .Include(item => item.Album)
                .FirstOrDefault(item => item.Id == songId);

            if (song == null)
            {
                return BadRequest(new {error = "Error: no song with such id exists"});
            }

            return Ok(song);
        }
    }
}