using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cancer_isp.Services
{
	public class StatisticsService : IStatisticsService
    {
        private readonly CancerIspContext _cancerIspContext;

        public StatisticsService(CancerIspContext cancerIspContext)
        {
            _cancerIspContext = cancerIspContext;
        }

        public List<ArtistWork> GetLatestReleases()
        {
            var result = _cancerIspContext.ArtistWork
                .Include(x => x.FkImage)
                .Where(x => x.CreationDate.Value.Month == DateTime.Now.Month)
                .ToList();

            return result;
        }

        public List<Rating> GetLatestRatings()
        {
            var result = _cancerIspContext.Rating
                .Include(x => x.FkArtistWork)
                .Where(x => x.Date.Value.Month == DateTime.Now.Month).ToList();

            return result;
        }

        public List<ArtistWork> GetTopRatedReleases()
        {
            var result = new List<ArtistWork>();
            var ratings = _cancerIspContext.Rating
                .Include(x => x.FkArtistWork).ToList();

            foreach (var rating in ratings)
            {
                if (rating.Score != null && rating.Score.Value > 5)
                {
                    result.Add(rating.FkArtistWork);
                }
            }

            return result;
        }
    }
}