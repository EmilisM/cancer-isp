using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IAdminService
    {
        bool ChangePermissions(int userId, UserRoleEnum role);
    }
}