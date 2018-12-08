using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cancer_isp.Services.Interfaces
{
    public interface IWorkRegistrationService
    {
        bool RegisterWork(ArtistWorkRegistrationModel model, User user);
        bool CheckArtist(ArtistWorkRegistrationModel model);
    }
}
