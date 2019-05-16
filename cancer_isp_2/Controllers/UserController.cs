using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp_2.Controllers
{
    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly CancerIspContext context;

        public UserController(CancerIspContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("playlists")]
        public IActionResult GetUserPlaylists(int userId = 1)
        {
            var playlists = context.Playlist
                .Where(playlist => playlist.UserId == userId)
                .ToList();

            return Ok(playlists);
        }

        [HttpPost]
        [Route("playlist/{playlistId}/add/{songId}")]
        public void AddSongToPlaylist(int songId, int playlistId)
        {
            var playlistSongEntity = new PlaylistSong
            {
                PlaylistId = playlistId,
                SongId = songId
            };

            context.PlaylistSong.Add(playlistSongEntity);
            context.SaveChanges();
        }

        [HttpPost]
        [Route("playlist/new/{playlistName}")]
        public void CreateNewPlaylist(string playlistName, int userId = 1)
        {
            var playlistEntity = new Playlist
            {
                Name = playlistName,
                UserId = userId
            };

            context.Playlist.Add(playlistEntity);
            context.SaveChanges();
        }
    }
}