using cancer_isp.Models.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cancer_isp.Services.Interfaces
{
    public interface IGenreService
    {
        List<Genre> GetGenres();
    }
}
