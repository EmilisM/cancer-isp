using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(string username);
    }
}