using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Image
    {
        public Image()
        {
            ArtistWork = new HashSet<ArtistWork>();
        }

        public int Id { get; set; }
        public string Photographer { get; set; }
        public DateTime? ImageDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public int FkArtistid { get; set; }

        public Artist FkArtist { get; set; }
        public ICollection<ArtistWork> ArtistWork { get; set; }
    }
}
