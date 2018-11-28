using System;
using System.Linq;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cancer_isp.Services
{
    public class UserService : IUserService
    {
        private readonly CancerIspContext _cancerIspContext;

        public UserService(CancerIspContext cancerIspContext)
        {
            _cancerIspContext = cancerIspContext;
        }

        public User GetUser(string username)
        {
            var user = _cancerIspContext.User
                .Include(item => item.FkUserProfileInfo)
                .Include(item => item.FkUserRole)
                .FirstOrDefault(item => string.Compare(item.Username, username, StringComparison.Ordinal) == 0);

            return user;
        }
    }
}