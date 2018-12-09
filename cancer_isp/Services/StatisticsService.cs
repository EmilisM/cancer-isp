using cancer_isp.Models;
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

        public List<TopRatedArtistWorkModel> GetTopRatedReleases()
        {
            var topScoresWithId = _cancerIspContext.Rating
                .GroupBy(item => item.FkArtistWork)
                .Select(item => new TopRatedArtistWorkModel
                    {FkWork = item.Key, AvgScore = item.Average(m => m.Score)})
                .OrderBy(item => item.AvgScore).ToList();

            return topScoresWithId;
        }

        public List<Rating> GetUserRatings(int id)
        {
            var result = _cancerIspContext.Rating.Include(x => x.FkUser)
                .Include(x => x.FkArtistWork)
                .Where(x => x.FkUser.Id == id).ToList();
            return result;
        }

        public List<Rating> GetArtistWorkRatings(int workId)
        {
            return _cancerIspContext.Rating
                .Include(x => x.FkArtistWork)
                .Where(x => x.FkArtistWork.Id == workId).ToList();
        }
    }
}