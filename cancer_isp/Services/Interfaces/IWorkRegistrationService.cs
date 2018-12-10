using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IWorkRegistrationService
    {
        bool RegisterWork(ArtistWork work, Artist artist);
        bool CheckIfArtistExists(string name);
    }
}