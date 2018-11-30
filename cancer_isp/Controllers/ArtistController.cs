using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class ArtistController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }
    }
}