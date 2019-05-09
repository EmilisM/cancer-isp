using System;
using System.Collections.Generic;

namespace cancer_isp_2.Database
{
    public class User
    {
        public User()
        {
            Artist = new HashSet<Artist>();
            Playlist = new HashSet<Playlist>();
            Rating = new HashSet<Rating>();
            Song = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public int? KarmaPoints { get; set; }
        public int? UserRoleId { get; set; }
        public int? UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Artist> Artist { get; set; }
        public virtual ICollection<Playlist> Playlist { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
