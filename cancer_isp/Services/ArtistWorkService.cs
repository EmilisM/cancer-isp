using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace cancer_isp.Services
{
    public class ArtistWorkService : IArtistWorkService
    {
        private readonly CancerIspContext _cancerIspContext;

        public ArtistWorkService(CancerIspContext cancerIspContext)
        {
            _cancerIspContext = cancerIspContext;
        }

        public ArtistWork GetArtistWork(int id)
        {
            var work = _cancerIspContext.ArtistWork
                .Include(item => item.FKGenre)
                .Include(item => item.FkImage)
                .Include(item => item.FKGenre.FkWorkType)
                .Include(item => item.FkUser)
                .FirstOrDefault(item => item.Id == id);
 
            return work;
        }

        public List<Artist> GetArtistWorks(int artistWorkId)
        {
            var creators = _cancerIspContext.ArtistCreated
                .Include(item => item.FkArtist)
                .Where(item => item.FkArtistWorkid == artistWorkId)
                .Select(item => item.FkArtist).ToList();

            return creators;
        }

        public List<ArtistWork> GetArtistWorksForArtist(int artistId)
        {
            var aristWorks = _cancerIspContext.ArtistCreated
                .Where(item => item.FkArtistid == artistId)
                .Select(item => item.FkArtistWork)
                .ToList();

            return aristWorks;
        }

        public List<ArtistWork> GetArtistWorks(string name)
        {
            var works = _cancerIspContext.ArtistWork
                .Include(item => item.FKGenre)
                .Where(item => item.Name.Contains(name))
                .ToList();

            return works;
        }
    }
}
