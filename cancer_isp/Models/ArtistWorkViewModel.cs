using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Models
{
    public class ArtistWorkViewModel
    {
        public ArtistWork ArtistWork { get; set; }
        public string Artists { get; set; }
        public List<Rating> ArtistWorkRatings { get; set; }
    }
    
}
