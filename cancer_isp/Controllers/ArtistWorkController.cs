using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistWorkController : BaseController
    {
        [Route("work")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("work/register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}