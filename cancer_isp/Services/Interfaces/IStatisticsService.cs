using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<ArtistWork> GetLatestReleases();
        List<Rating> GetLatestRatings();
        List<ArtistWork> GetTopRatedReleases();
    }
}
