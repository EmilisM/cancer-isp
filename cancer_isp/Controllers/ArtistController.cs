using AutoMapper;
using cancer_isp.Models;
using cancer_isp.Models.Dbo;
using cancer_isp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace cancer_isp.Controllers
{
    public class ArtistController : BaseController
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IArtistWorkService _artistWorkService;

        public ArtistController(IArtistService artistService, IMapper mapper, IUserService userService,
            IArtistWorkService artistWorkService)
        {
            _artistService = artistService;
            _mapper = mapper;
            _userService = userService;
            _artistWorkService = artistWorkService;
        }

        [HttpGet]
        [Route("artist/{id}")]
        public IActionResult Index(int id)
        {
            var artist = _artistService.GetArtist(id);
            var occupations = _artistService.GetOccupations();

            var comments = _artistService.GetArtistComments(artist.Id);
            var artistWorks = _artistWorkService.GetArtistWorksForArtist(artist.Id);

            var artistViewModel = new ArtistViewModel
            {
                Artist = artist,
                Occupations = occupations,
                Comments = comments,
                ArtistWorks = artistWorks
            };

            return View(artistViewModel);
        }

        [HttpGet]
        [Route("artist/register")]
        public IActionResult Register()
        {
            var occupations = _artistService.GetOccupations();

            var artistRegistrationModel = new ArtistRegistrationModel
            {
                Occupations = occupations
            };

            return View(artistRegistrationModel);
        }

        [HttpGet]
        [Route("artist/list")]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterArtist(ArtistRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                var result = _artistService.GetOccupations();
                model.Occupations = result;

                return View("Register", model);
            }

            var artist = _mapper.Map<Artist>(model);

            var user = _userService.GetUser(Username);

            if (user == null)
            {
                return RedirectToAction("LogIn", "Login");
            }

            artist.FkUserid = user.Id;
            artist.FkImage = new Image
            {
                ImageDate = DateTime.Now,
                ImageUrl = model.ImageUrl
            };

            var success = _artistService.InsertNewArtist(artist);

            if (success)
            {
                TempData["success"] = "Artist registration successful !";
            }

            return RedirectToAction("Register");
        }
    }
}