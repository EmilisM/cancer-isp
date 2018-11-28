using cancer_isp.Models;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IAuthService
    {
        User AuthUser(LoginModel model, bool admin = false);

        bool RegisterUser(RegistrationModel model);
    }
}