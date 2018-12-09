using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class TopRatedArtistWorkModel
    {
        public decimal? AvgScore { get; set; }
        public ArtistWork FkWork { get; set; }
    }
}
