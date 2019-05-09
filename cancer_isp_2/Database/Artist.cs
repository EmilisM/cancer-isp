using System;
using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Artist
    {
        public Artist()
        {
            ArtistAlbum = new HashSet<ArtistAlbum>();
            ArtistSong = new HashSet<ArtistSong>();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Description { get; set; }
        public DateTime? OriginDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ArtistAlbum> ArtistAlbum { get; set; }
        public virtual ICollection<ArtistSong> ArtistSong { get; set; }
    }
}
