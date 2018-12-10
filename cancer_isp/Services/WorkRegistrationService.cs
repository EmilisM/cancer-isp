using System;
using System.Linq;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;

namespace cancer_isp.Services
{
    public class WorkRegistrationService : IWorkRegistrationService
    {
        private readonly CancerIspContext _entities;


        public WorkRegistrationService(CancerIspContext entities)
        {
            _entities = entities;
        }

        public bool CheckIfArtistExists(string name)
        {
            var artist = _entities.Artist.FirstOrDefault(item => item.FullName.Contains(name));

            return artist != null;
        }

        public bool RegisterWork(ArtistWork work, Artist artist)
        {
            try
            {
                _entities.ArtistWork.Add(work);

                _entities.SaveChanges();

                var addedWork = _entities.ArtistWork
                    .FirstOrDefault(item => item.Name.Contains(work.Name));

                if (addedWork != null)
                {
                    var artistCreated = new ArtistCreated
                    {
                        FkArtistWorkid = addedWork.Id,
                        FkArtistid = artist.Id
                    };

                    _entities.ArtistCreated.Add(artistCreated);

                    _entities.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}