using System;
using System.Collections.Generic;
using System.Linq;
using cancer_isp_2.Database;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Controllers
{
    public class GetSongRecommendations : IGetRecommendations<Song>
    {
        private readonly CancerIspContext _context;

        public GetSongRecommendations(CancerIspContext context)
        {
            _context = context;
        }

        public IEnumerable<Song> GetRecommendations()
        {
            var songs = _context.Song
                .Include(song => song.Artists)
                .ThenInclude(song => song.Artist)
                .Where(song =>
                    song.ReleaseDate.HasValue && song.ReleaseDate.Value.Month == DateTime.Now.Month);

            return songs;
        }
    }
}