namespace cancer_isp_2.Database
{
    public class ArtistAlbum
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
