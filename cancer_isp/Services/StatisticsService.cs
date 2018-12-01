using System;
using System.Collections.Generic;
using System.Linq;
using cancer_isp.Services.Interfaces;
using cancer_isp.Models.Dbo;

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
            var result = _cancerIspContext.ArtistWork.
                Where(x => x.CreationDate.Value.Month == DateTime.Now.Month).ToList();

            return result;
        }
    }
}
