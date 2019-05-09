using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Genre
    {
        public Genre()
        {
            SongGenre = new HashSet<SongGenre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SongGenre> SongGenre { get; set; }
    }
}
