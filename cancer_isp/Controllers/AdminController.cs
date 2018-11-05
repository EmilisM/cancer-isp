using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class AdminController : BaseController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}