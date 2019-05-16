using System;
using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Song
    {
        public Song()
        {
            Artists = new HashSet<ArtistSong>();
            PlaylistSong = new HashSet<PlaylistSong>();
            Ratings = new HashSet<Rating>();
            Genres = new HashSet<SongGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? LengthInSeconds { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public int? AlbumId { get; set; }
        public int? UserId { get; set; }
        public string YoutubeVideoId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ArtistSong> Artists { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSong { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<SongGenre> Genres { get; set; }
    }
}
