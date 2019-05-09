using System;

namespace cancer_isp_2.Database
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }
    }
}
