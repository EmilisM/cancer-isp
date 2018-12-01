using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Services.Interfaces
{
    public interface IArtistWorkService
    {
        ArtistWork GetArtistWork(int id);
        List<Artist> GetArtistWorkCreators(int artistWorkId);
    }
}
