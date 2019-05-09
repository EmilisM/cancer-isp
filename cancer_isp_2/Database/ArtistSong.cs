namespace cancer_isp_2.Database
{
    public class ArtistSong
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
    }
}
