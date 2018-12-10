using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace cancer_isp.Services
{
    public class ArtistService : IArtistService
    {
        private readonly CancerIspContext _cancerIspContext;

        public ArtistService(CancerIspContext cancerIspContext)
        {
            _cancerIspContext = cancerIspContext;
        }

        public Artist GetArtist(int id)
        {
            var artist = _cancerIspContext.Artist
                .Include(item => item.FkOccupation)
                .Include(item => item.FkUser)
                .Include(item => item.FkImage)
                .FirstOrDefault(item => item.Id == id);

            return artist;
        }

        public Artist GetArtist(string name)
        {
            var artist = _cancerIspContext.Artist
                .Include(item => item.FkOccupation)
                .Include(item => item.FkUser)
                .Include(item => item.FkImage)
                .FirstOrDefault(item => item.FullName.Contains(name));

            return artist;
        }

        public List<Artist> GetArtists(string pseudonym)
        {
            var artists = _cancerIspContext.Artist
                .Include(item => item.FkOccupation)
                .Where(item => item.Pseudonym.Contains(pseudonym))
                .ToList();
            return artists;
        }

        public List<Artist> GetArtists()
        {
            var artists = _cancerIspContext.Artist.ToList();

            return artists;
        }

        public List<Occupation> GetOccupations()
        {
            var occupations = _cancerIspContext.Occupation.ToList();

            return occupations;
        }

        public bool InsertNewArtist(Artist model)
        {
            try
            {
                _cancerIspContext.Artist.Add(model);
                _cancerIspContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public List<Comment> GetArtistComments(int artistId)
        {
            var comments = _cancerIspContext.Comment.Where(item => item.FkArtistid == artistId).ToList();

            return comments;
        }
    }
}