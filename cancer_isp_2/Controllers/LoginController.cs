using System.Linq;
using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp_2.Controllers
{
    [Route("api/login")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase

    {
        private readonly CancerIspContext context;

        public LoginController(CancerIspContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(string username)
        {
            var newuser = context.User
                .FirstOrDefault(user => user.Username == username);

            return Ok(newuser);
        }
    }
}