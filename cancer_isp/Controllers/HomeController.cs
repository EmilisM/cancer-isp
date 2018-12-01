using cancer_isp.Models.Dbo;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace cancer_isp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;

        public HomeController(CancerIspContext context, IStatisticsService statisticsService, IMapper mapper)
        {
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        [Route("home")]
        public IActionResult Index()
        {
            var artisWorks = _statisticsService.GetLatestReleases();

            return View("Index", artisWorks);
        }
    }
}