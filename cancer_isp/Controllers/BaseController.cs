using cancer_isp.Helpers;
using cancer_isp.Models.Dbo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace cancer_isp.Controllers
{
    public class BaseController : Controller
    {
        public string Username => User.Claims.First(item => item.Type == ClaimTypes.Name).Value;

        public UserRoleEnum UserRole => User.Claims.First(item => item.Type == ClaimTypes.Role).Value.ToEnum<UserRoleEnum>();
    }
}