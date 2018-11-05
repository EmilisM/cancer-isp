using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class User
    {
        public User()
        {
            Artist = new HashSet<Artist>();
            ArtistWork = new HashSet<ArtistWork>();
            Comment = new HashSet<Comment>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? KarmaPoints { get; set; }
        public string Email { get; set; }
        public UserStateEnum UserState { get; set; }
        public int FkUserRoleid { get; set; }
        public int FkUserProfileInfoid { get; set; }

        public UserProfileInfo FkUserProfileInfo { get; set; }
        public UserRole FkUserRole { get; set; }
        public ICollection<Artist> Artist { get; set; }
        public ICollection<ArtistWork> ArtistWork { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
