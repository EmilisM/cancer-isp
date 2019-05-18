using System.Linq;
using cancer_isp_2.Database;
using cancer_isp_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp_2.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public SearchController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SearchForItems(SearchModel search)
        {
            if (string.IsNullOrEmpty(search.SearchField) && string.IsNullOrEmpty(search.SearchTerm))
            {
                return BadRequest("Error: provided fields are null");
            }

            switch (search.SearchField)
            {
                case "Song":
                {
                    var songs = _context.Song.Where(song => song.Name.Contains(search.SearchTerm));
                    return Ok(songs);
                }

                case "Artist":
                {
                    var artists = _context.Artist.Where(artist => artist.Name.Contains(search.SearchTerm));
                    return Ok(artists);
                }

                case "Album":
                {
                    var albums = _context.Album.Where(album => album.Name.Contains(search.SearchTerm));
                    return Ok(albums);
                }

                default:
                    return BadRequest("Error: provided search field doesn't exist");
            }
        }
    }
}