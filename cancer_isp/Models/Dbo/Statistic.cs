namespace cancer_isp.Models.Dbo
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FkRatingid { get; set; }

        public Rating FkRating { get; set; }
    }
}
