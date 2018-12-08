using System;
using System.Linq;
using cancer_isp.Models;
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

        public bool CheckArtist(ArtistWorkRegistrationModel model)
        {
            var artist = _entities.Artist.Where(item => item.FullName.Contains(model.Artist)).FirstOrDefault();
            if (artist == null)
            {
                return false;
            }
            else return true;
        }

        public bool RegisterWork(ArtistWorkRegistrationModel model, User user)
        {
            var artist = _entities.Artist.Where(item => item.FullName.Contains(model.Artist)).FirstOrDefault();
            
            try
            {
                var newWork = new ArtistWork
                {

                    Name = model.Name,
                    CreationDate = model.CreationDate,
                    LengthInSeconds = model.Length,
                    RecordLabel = model.RecordLabel,
                    Description = model.Description,
                    PublishDate = model.PublishDate,
                    FkUserid = user.Id,
                    FkImageid = 3,
                    FKGenreid = 1
                    

                };

                _entities.ArtistWork.Add(newWork);
               /* if (artist != null)
                {
                    var work = _entities.ArtistWork
                    .Where(item => item.Name == model.Name && item.CreationDate == model.CreationDate && item.LengthInSeconds == model.Length).FirstOrDefault();

                    var artistCreatedWork = new ArtistCreated
                    {
                        FkArtistid = artist.Id,
                        FkArtistWorkid = work.Id
                    };

                    _entities.ArtistCreated.Add(artistCreatedWork);
                }*/
                
                _entities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}