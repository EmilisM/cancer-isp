using System;
using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Album
    {
        public Album()
        {
            ArtistAlbum = new HashSet<ArtistAlbum>();
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual ICollection<ArtistAlbum> ArtistAlbum { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
