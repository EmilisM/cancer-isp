using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IStatisticsService _statisticsService;

        public HomeController(CancerIspContext context, IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [Route("home")]
        [HttpGet]
        public IActionResult Index()
        {
            var latestReleases = _statisticsService.GetLatestReleases();
            var latestRatings = _statisticsService.GetLatestRatings();
            var topRatedReleases = _statisticsService.GetTopRatedReleases();

            var statisticViewModel = new StatisticViewModel
            {
                LatestReleases = latestReleases,
                LatestRatings = latestRatings,
                TopRatedReleases = topRatedReleases
            };

            return View("Index", statisticViewModel);
        }
    }
}