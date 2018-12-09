using cancer_isp.Models.Dbo;
using System.Collections.Generic;
using cancer_isp.Models;

namespace cancer_isp.Services.Interfaces
{
    public interface IStatisticsService
    {
        List<ArtistWork> GetLatestReleases();
        List<Rating> GetLatestRatings();
        List<TopRatedArtistWorkModel> GetTopRatedReleases();
        List<Rating> GetUserRatings(int userId);
        List<Rating> GetArtistWorkRatings(int workId);
    }
}
