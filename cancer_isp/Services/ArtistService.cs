using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    }
}
