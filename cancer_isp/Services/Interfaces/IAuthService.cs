using cancer_isp.Models;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IAuthService
    {
        User AuthUser(LoginModel model);

        void RegisterUser(RegistrationModel model);
    }
}