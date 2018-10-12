using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Rating
    {
        public Rating()
        {
            Statistic = new HashSet<Statistic>();
        }

        public int Id { get; set; }
        public decimal? Score { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public int FkUserid { get; set; }
        public int FkArtistWorkid { get; set; }

        public ArtistWork FkArtistWork { get; set; }
        public User FkUser { get; set; }
        public ICollection<Statistic> Statistic { get; set; }
    }
}
