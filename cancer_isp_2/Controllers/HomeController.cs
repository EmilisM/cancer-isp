using System;
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
        [Route("top/{rangeDays}")]
        public IActionResult GetNewSongs(int rangeDays)
        {
            var songs = _context.Song
                .Include(song => song.Ratings)
                .Include(song => song.Image)
                .Include(song => song.Artists)
                .ThenInclude(song => song.Artist)
                .Select(song => new
                {
                    Song = song,
                    AverageRating = song.Ratings
                        .Where(rating =>
                            rating.CreationDate.HasValue &&
                            (rangeDays == 0 || (DateTime.Now - rating.CreationDate.Value).Days < rangeDays))
                        .Average(rating => rating.Points)
                })
                .ToList();

            var orderedSongs = songs.OrderByDescending(song => song.AverageRating).Take(20).ToList();

            return Ok(orderedSongs);
        }

        [HttpGet]
        [Route("recommended/{UserId}")]
        public IActionResult GetRecommendedSongs(int UserId = 1)
        {
            //gets newest songs
            var recommendations = _context.Song
                .OrderByDescending(song => song.Id)
                .Take(5)
                .ToList();
            
            //doesnt work
            /*
            var recommendations = _context.Song
                .Where(song => song.Ratings)


            var ratings = _context.Rating.Join
                .Where(rating => rating.UserId == UserId)
                .Where(rating => rating.Points >= 9)
                .ToList();

            //var recommendations = _context.Song.Where(song => song.Genres == ratings).ToList();
            */
            /*
            var songs = _context.Song
                .Include(song => song.Genres)
                .Include(song => song.Image)
                .Include(song => song.Artists)
                .ThenInclude(song => song.Artist)
                .Select(song => new
                {
                    Song = song,
                    RatedSong = song.Ratings
                    .Where(rating => rating.UserId == UserId)
                    .OrderBy(rating => rating.Points).First().SongId,
                    Genre = song.Genres
                })
                .ToList();
                */
            return Ok(recommendations);
        }
    }
}