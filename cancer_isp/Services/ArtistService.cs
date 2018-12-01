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
                .FirstOrDefault(item => item.Id == id);

            return artist;
        }

        public Image GetArtistImage(int id)
        {
            var image = _cancerIspContext.Image.FirstOrDefault(item => item.Id == id);

            return image;
        }

        public List<Occupation> GetOccupations()
        {
            var occupations = _cancerIspContext.Occupation.ToList();

            return occupations;
        }
    }
}
