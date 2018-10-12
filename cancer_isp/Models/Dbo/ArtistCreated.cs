namespace cancer_isp.Models.Dbo
{
    public partial class ArtistCreated
    {
        public int FkArtistWorkid { get; set; }
        public int FkArtistid { get; set; }

        public Artist FkArtist { get; set; }
        public ArtistWork FkArtistWork { get; set; }
    }
}
