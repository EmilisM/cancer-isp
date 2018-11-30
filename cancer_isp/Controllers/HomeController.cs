using cancer_isp.Models.Dbo;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(CancerIspContext context)
        {
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}