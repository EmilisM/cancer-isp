using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistWorkController : Controller
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