using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Occupation
    {
        public Occupation()
        {
            Artist = new HashSet<Artist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Artist> Artist { get; set; }
    }
}
