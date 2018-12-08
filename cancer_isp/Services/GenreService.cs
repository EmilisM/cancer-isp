using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cancer_isp.Services
{
    public class GenreService : IGenreService
    {
        private readonly CancerIspContext _cancerIspContext;

        public GenreService(CancerIspContext cancerIspContext)
        {
            _cancerIspContext = cancerIspContext;
        }

        public List<Genre> GetGenres()
        {
            var genres = _cancerIspContext.Genre.ToList();

            return genres;
        }
    }
}
