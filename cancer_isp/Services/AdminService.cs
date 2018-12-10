using System.Linq;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;

namespace cancer_isp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserService _userService;
        private readonly CancerIspContext _cancerIspContext;

        public AdminService(IUserService userService, CancerIspContext cancerIspContext)
        {
            _userService = userService;
            _cancerIspContext = cancerIspContext;
        }

        public bool ChangePermissions(int userId, UserRoleEnum role)
        {
            var user = _userService.GetUser(userId);

            if (user == null)
            {
                return false;
            }

            var newRole = _cancerIspContext.UserRole.FirstOrDefault(item => item.Name == role);

            user.UserRole = newRole;
            _cancerIspContext.User.Update(user);
            _cancerIspContext.SaveChanges();

            return true;
        }
    }
}