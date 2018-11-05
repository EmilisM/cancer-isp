using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public UserRoleEnum Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
