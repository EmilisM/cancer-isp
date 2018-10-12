using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Genre
    {
        public Genre()
        {
            ArtistWork = new HashSet<ArtistWork>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? YearOfDiscovery { get; set; }
        public string Description { get; set; }
        public int FkWorkTypeid { get; set; }

        public WorkType FkWorkType { get; set; }
        public ICollection<ArtistWork> ArtistWork { get; set; }
    }
}
