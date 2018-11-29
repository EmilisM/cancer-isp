using System;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            
        }

        public ProfileViewModel(User user)
        {
            FromUser(user);
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Description { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int KarmaPoints { get; set; }

        public void FromUser(User user)
        {
            Username = user.Username;
            FirstName = user.FkUserProfileInfo.FirstName;
            LastName = user.FkUserProfileInfo.LastName;
            RegistrationDate = user.RegistrationDate ?? new DateTime();
            Description = user.FkUserProfileInfo.Description;
            Birthdate = user.FkUserProfileInfo.Birthdate ?? new DateTime();
            PhoneNumber = user.FkUserProfileInfo.PhoneNumber;
            Email = user.Email;
            KarmaPoints = user.KarmaPoints ?? 0;
        }
    }
}