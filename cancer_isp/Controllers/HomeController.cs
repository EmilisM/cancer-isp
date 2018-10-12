using cancer_isp.Models.Dbo;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class HomeController : Controller
    {
        private readonly CancerIspContext _context;

        public HomeController(CancerIspContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}