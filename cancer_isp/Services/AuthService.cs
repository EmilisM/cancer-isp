using System;
using System.Linq;
using System.Security.Cryptography;
using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace cancer_isp.Services
{
    public class AuthService : IAuthService
    {
        private readonly CancerIspContext _entities;
        private readonly IUserService _userService;

        public AuthService(CancerIspContext entities, IUserService userService)
        {
            _entities = entities;
            _userService = userService;
        }

        public User AuthUser(LoginViewModel model, bool admin = false)
        {
            var user = _userService.GetUser(model.Username);

            if (user == null || user.UserState == UserStateEnum.Blocked || admin && user.UserRole.Name == UserRoleEnum.Administrator)
            {
                return null;
            }

            byte[] saltArray = Convert.FromBase64String(user.PasswordSalt);

            var hashToCompare = Convert.ToBase64String(KeyDerivation.Pbkdf2(model.Password, saltArray, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));

            return string.Compare(user.PasswordHash, hashToCompare, StringComparison.Ordinal) == 0 ? user : null;
        }

        public bool RegisterUser(RegistrationModel model)
        {
            byte[] salt = new byte[128 / 8];

            var random = RandomNumberGenerator.Create();
            random.GetBytes(salt);

            try
            {
                string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(model.Password, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));

                var newUserProfile = new UserProfileInfo();

                var newUser = new User
                {
                    Username = model.Username,
                    RegistrationDate = DateTime.Now,
                    PasswordHash = passwordHash,
                    PasswordSalt = Convert.ToBase64String(salt),
                    UserState = UserStateEnum.Active,
                    Email = model.Email,
                    UserRole = _entities.UserRole.First(item => item.Name == UserRoleEnum.User),
                    UserProfileInfo = newUserProfile
                };

                _entities.User.Add(newUser);
                _entities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}