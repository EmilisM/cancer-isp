using System;

namespace cancer_isp.Models.Api
{
    public class UserRatingModel
    {
        public int Id { get; set; }
        public decimal? Score { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }

        public string WorkName { get; set; }
    }
}
