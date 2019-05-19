using Microsoft.AspNetCore.Mvc;
using cancer_isp_2.Database;
using System.Linq;

namespace cancer_isp_2.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly CancerIspContext _context;

        public AdminController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("block/{userId}")]
        public IActionResult BlockUser(int userId)
        {
            var user = _context.User
                .FirstOrDefault(userid => userid.UserProfileId == userId);

            user.UserRoleId = 4;

            _context.User.Add(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}