using cancer_isp.Models.Dbo;

namespace cancer_isp.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Returns null if user with such username doesn't exist
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        void UpdateUser(User user);

        bool IsEmailValid(string email);

        User GetUser(int id);
	}
}