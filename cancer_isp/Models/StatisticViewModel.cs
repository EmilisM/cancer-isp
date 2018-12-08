using System.ComponentModel.DataAnnotations;
using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Models
{
    public class StatisticViewModel
    {
        public List<ArtistWork> LatestReleases { get; set; }

        public List<Rating> LatestRatings { get; set; }

        public List<TopRatedArtistWorkModel> TopRatedReleases { get; set; }
    }
}