using System.Collections.Generic;

namespace cancer_isp_2.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LengthInSeconds { get; set; }
        public string YoutubeVideoId { get; set; }
        public string ReleaseDate { get; set; }

		
		public string ArtistId { get; set; }
        public int AlbumId { get; set; }

        public List<int> GenreIds { get; set; }
    }
}