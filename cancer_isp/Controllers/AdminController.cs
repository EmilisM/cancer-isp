using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}