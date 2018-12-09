using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cancer_isp.Models.Api
{
    public class ArtistWorkModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LengthInSeconds { get; set; }
        public string RecordLabel { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
