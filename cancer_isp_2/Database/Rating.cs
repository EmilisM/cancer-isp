using System;

namespace cancer_isp_2.Database
{
    public class Rating
    {
        public int Id { get; set; }
        public int? Points { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Comment { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }

        public virtual Song Song { get; set; }
        public virtual User User { get; set; }
    }
}
