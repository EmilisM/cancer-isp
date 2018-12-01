using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Image
    {
        public Image()
        {
            ArtistWork = new HashSet<ArtistWork>();
            Artist = new HashSet<Artist>();
        }

        public int Id { get; set; }
        public string Photographer { get; set; }
        public DateTime? ImageDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }

        public ICollection<ArtistWork> ArtistWork { get; set; }
        public ICollection<Artist> Artist { get; set; }
    }
}
