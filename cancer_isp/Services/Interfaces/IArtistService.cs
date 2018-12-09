using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Services.Interfaces
{
    public interface IArtistService
    {
        Artist GetArtist(int id);

        Image GetArtistImage(int id);

        List<Occupation> GetOccupations();
    }
}
