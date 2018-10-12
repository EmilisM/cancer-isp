using System;
using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistCreated = new HashSet<ArtistCreated>();
            Comment = new HashSet<Comment>();
            Image = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string Pseudonym { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Description { get; set; }
        public DateTime? OccupationStartDate { get; set; }
        public int FkOccupationid { get; set; }
        public int FkUserid { get; set; }

        public Occupation FkOccupation { get; set; }
        public User FkUser { get; set; }
        public ICollection<ArtistCreated> ArtistCreated { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
