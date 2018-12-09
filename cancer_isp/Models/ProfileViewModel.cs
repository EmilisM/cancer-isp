using System;
using System.Collections.Generic;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Description { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int KarmaPoints { get; set; }

        public List<Rating> UserRatings { get; set; }
    }
}