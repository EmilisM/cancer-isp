using cancer_isp.Models.Dbo;
using System.Collections.Generic;

namespace cancer_isp.Services.Interfaces
{
    public interface IArtistService
    {
        Artist GetArtist(int id);
        List<Occupation> GetOccupations();
        bool InsertNewArtist(Artist model);
        List<Comment> GetArtistComments(int artistId);
        Artist GetArtist(string name);
    }
}