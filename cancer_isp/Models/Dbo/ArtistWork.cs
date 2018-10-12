using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class ArtistWork
    {
        public ArtistWork()
        {
            ArtistCreated = new HashSet<ArtistCreated>();
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LengthInSeconds { get; set; }
        public string RecordLabel { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public int FkUserid { get; set; }
        public int FkImageid { get; set; }
        public int FKGenreid { get; set; }

        public Genre FKGenre { get; set; }
        public Image FkImage { get; set; }
        public User FkUser { get; set; }
        public ICollection<ArtistCreated> ArtistCreated { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
