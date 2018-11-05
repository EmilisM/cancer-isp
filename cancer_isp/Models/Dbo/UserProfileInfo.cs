using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public class UserProfileInfo
    {
        public UserProfileInfo()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<User> User { get; set; }
    }
}
