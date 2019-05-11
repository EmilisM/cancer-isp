using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public AlbumController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{albumId}")]
        public IActionResult GetAlbum(int albumId)
        {
            var album = _context.Album
                .Include(item => item.Songs)
                .Include(item => item.Artists)
                .ThenInclude(item => item.Artist)
                .FirstOrDefault(item => item.Id == albumId);

            if (album == null)
            {
                return BadRequest(new {error = "Error: no album with such id exists"});
            }

            return Ok(album);
        }
    }
}