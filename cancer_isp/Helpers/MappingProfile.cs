using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Models.Api;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ProfileViewModel>()
                .ForMember(m => m.FirstName, o => o.MapFrom(m => m.UserProfileInfo.FirstName))
                .ForMember(m => m.LastName, o => o.MapFrom(m => m.UserProfileInfo.LastName))
                .ForMember(m => m.Description, o => o.MapFrom(m => m.UserProfileInfo.Description))
                .ForMember(m => m.Birthdate, o => o.MapFrom(m => m.UserProfileInfo.Birthdate))
                .ForMember(m => m.PhoneNumber, o => o.MapFrom(m => m.UserProfileInfo.PhoneNumber));

            CreateMap<ProfileViewModel, User>()
                .ForPath(m => m.UserProfileInfo.FirstName, o => o.MapFrom(m => m.FirstName))
                .ForPath(m => m.UserProfileInfo.LastName, o => o.MapFrom(m => m.LastName))
                .ForPath(m => m.UserProfileInfo.Birthdate, o => o.MapFrom(m => m.Birthdate))
                .ForPath(m => m.UserProfileInfo.Description, o => o.MapFrom(m => m.Description))
                .ForPath(m => m.UserProfileInfo.PhoneNumber, o => o.MapFrom(m => m.PhoneNumber));

            CreateMap<Rating, UserRatingModel>()
                .ForMember(prop => prop.WorkName, source => source.MapFrom(m => m.FkArtistWork.Name));

            CreateMap<Rating, WorkRatingModel>();
            CreateMap<ArtistWork, ArtistWorkModel>();

            CreateMap<Artist, ArtistRegistrationModel>();
            CreateMap<ArtistRegistrationModel, Artist>()
                .ForMember(src => src.FkOccupationid, dest => dest.MapFrom(o => o.OccupationId));

            CreateMap<ArtistWork, ArtistWorkRegistrationModel>();
            CreateMap<ArtistWorkRegistrationModel, ArtistWork>()
                .ForMember(dest => dest.FKGenreid, source => source.MapFrom(m => m.GenreId));
        }
    }
}