using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IArtistService
    {
        Artist GetArtist(int id);
    }
}
