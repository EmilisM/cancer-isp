using System;
using System.Linq;
using cancer_isp_2.Database;
using cancer_isp_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

// ReSharper disable InconsistentNaming

namespace cancer_isp_2.Controllers
{
    [Route("api/song")]
    [Produces("application/json")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly CancerIspContext _context;
        private readonly SpotifyWebAPI _spotifyWebApi;

        public SongController(CancerIspContext context, SpotifyWebAPI spotifyWebApi)
        {
            _context = context;
            _spotifyWebApi = spotifyWebApi;
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

        [HttpPost]
        [Route("{songId}/new/comment")]
        public IActionResult AddNewComment(int songId, CommentModel model)
        {
            var newRating = new Rating
            {
                Points = model.Rating,
                Comment = model.Comment,
                CreationDate = DateTime.Now,
                SongId = songId,
                UserId = 1
            };

            _context.Rating.Add(newRating);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("{songId}")]
        public IActionResult getSong(int songId)
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

            var searchItem =
                requestSongDetails(song.Name, string.Join(", ", song.Artists.Select(x => x.Artist.Name)));

            var audioAnalysis = validateSongDetails(searchItem);

            return Ok(new {song, songDetails = audioAnalysis});
        }

        [HttpPost]
        [Route("songs/create")]
        public IActionResult AddNewSong(Song model)
        {
            var newSong = new Song
            {
                Name = model.Name,
                Artists = model.Artists,
                ReleaseDate = model.ReleaseDate,
                LengthInSeconds = model.LengthInSeconds,
                Description = model.Description,
                ImageId = model.ImageId,
                AlbumId = model.AlbumId,
                YoutubeVideoId = model.YoutubeVideoId,
                UserId = 1
            };

            _context.Song.Add(newSong);
            _context.SaveChanges();

            return Ok();
        }

        private SearchItem requestSongDetails(string songName, string artistName)
        {
            var searchItem = _spotifyWebApi?.SearchItems($"{artistName} {songName}", SearchType.Track, limit: 1);

            return searchItem;
        }

        private AudioFeatures validateSongDetails(SearchItem items)
        {
            if (items.Tracks.Items == null || !items.Tracks.Items.Any())
            {
                return null;
            }

            return _spotifyWebApi.GetAudioFeatures(items.Tracks.Items.Single().Id);
        }
    }
}