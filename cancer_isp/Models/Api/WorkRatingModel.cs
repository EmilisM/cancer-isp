using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cancer_isp.Models.Api
{
    public class WorkRatingModel
    {
        public int Id { get; set; }
        public decimal? Score { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
    }
}
