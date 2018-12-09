using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;

namespace cancer_isp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public ValuesController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public List<Rating> Get()
        {
            return _statisticsService.GetLatestRatings();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}