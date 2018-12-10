using System;

namespace cancer_isp.Models.Dbo
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public string Name { get; set; }
        public int FkArtistid { get; set; }
        public int FkUserid { get; set; }

        public Artist FkArtist { get; set; }
        public User FkUser { get; set; }
    }
}
