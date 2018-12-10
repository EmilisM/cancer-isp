using System.Collections.Generic;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class ArtistWorkFilter
    {
        public string Name { get; set; }

        public List<ArtistWork> Works { get; set; }
    }
}