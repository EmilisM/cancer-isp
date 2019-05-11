using System;
using System.Collections.Generic;
using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Controllers
{
    [Route("api/artist")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public ArtistController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("new")]
        public IEnumerable<object> GetNewArtists()
        {
            var artists = _context.Artist
                .Where(artist => artist.OriginDate.HasValue && artist.OriginDate.Value.Month == DateTime.Now.Month)
                .Select(artist => new {artist.Id, artist.Alias, artist.FullName, artist.Description});

            return artists;
        }

        [HttpGet]
        [Route("{artistId}")]
        public IActionResult GetArtist(int artistId)
        {
            var artist = _context.Artist
                .Include(item => item.Albums)
                .ThenInclude(albums => albums.Album)
                .Include(item => item.Songs)
                .ThenInclude(songs => songs.Song)
                .FirstOrDefault(item => item.Id == artistId);

            if (artist == null)
            {
                return BadRequest(new {error = "Error: no artist with such id exists"});
            }

            return Ok(artist);
        }
    }
}