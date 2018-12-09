using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cancer_isp.Models.Api;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace cancer_isp.Controllers
{
    [Route("api")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;

        public StatisticsApiController(IStatisticsService statisticsService, IMapper mapper)
        {
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        [Route("getlatestreleases")]
        public string GetLatestReleases()
        {
            var result = _statisticsService.GetLatestReleases();
            var artistWorksModelList = result.Select(item => _mapper.Map<ArtistWork, ArtistWorkModel>(item));

            var jsonList = JsonConvert.SerializeObject(artistWorksModelList);
            return jsonList;
        }

        [Route("getlatestratings")]
        public string GetLatestRatings()
        {
            var result = _statisticsService.GetLatestRatings();
            var ratingModelList = result.Select(item => _mapper.Map<Rating, UserRatingModel>(item));

            var jsonObject = JsonConvert.SerializeObject(ratingModelList);
            return jsonObject;
        }

        [Route("gettopratedreleases")]
        public string GetTopRatedReleases()
        {
            var result = _statisticsService.GetTopRatedReleases();

            var jsonObject = JsonConvert.SerializeObject(result);
            return jsonObject;
        }

        [Route("getuserratings/{userId}")]
        [HttpGet]
        public string GetUserRatings(int userId)
        {
            var result = _statisticsService.GetUserRatings(userId);
            var ratingModelList = result.Select(item => _mapper.Map<Rating, UserRatingModel>(item));

            var jsonList = JsonConvert.SerializeObject(ratingModelList);
            return jsonList;
        }

        [Route("getartistworkratings/{workId}")]
        [HttpGet]
        public string GetArtistWorkRatings(int workId)
        {
            var result = _statisticsService.GetArtistWorkRatings(workId);
            var ratingModelList = result.Select(item => _mapper.Map<Rating, WorkRatingModel>(item));

            var jsonList = JsonConvert.SerializeObject(ratingModelList);
            return jsonList;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
