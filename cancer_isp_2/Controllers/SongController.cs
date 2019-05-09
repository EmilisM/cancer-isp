using cancer_isp_2.Database;
using Microsoft.AspNetCore.Mvc;

namespace cancer_isp_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private CancerIspContext _context;

        public SongController(CancerIspContext context)
        {
            _context = context;
        }

        [HttpGet]
        public void GetSong(int id)
        {
        }
    }
}