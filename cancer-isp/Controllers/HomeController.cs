using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new[] {"First", "Second"});
        }
    }
}