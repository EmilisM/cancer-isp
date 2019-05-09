using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistSong = new HashSet<PlaylistSong>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSong { get; set; }
    }
}
