using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Models
{
    public class ArtistViewModel
    {
        public Artist Artist { get; set; }

        public List<Occupation> Occupations { get; set; }

        public List<Comment> Comments { get; set; }

        public List<ArtistWork> ArtistWorks { get; set; }
    }
}