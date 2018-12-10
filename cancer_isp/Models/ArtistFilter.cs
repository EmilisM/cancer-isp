using System.Collections.Generic;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class ArtistFilter
    {
        public string Pseudonym { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
