using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class Image
    {
        public Image()
        {
            Album = new HashSet<Album>();
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Album> Album { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
