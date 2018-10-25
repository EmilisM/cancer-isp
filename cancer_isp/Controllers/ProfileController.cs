using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
	public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}