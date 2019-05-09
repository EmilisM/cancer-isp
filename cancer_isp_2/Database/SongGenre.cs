namespace cancer_isp_2.Database
{
    public class SongGenre
    {
        public int SongId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Song Song { get; set; }
    }
}
