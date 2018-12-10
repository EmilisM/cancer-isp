using cancer_isp.Models.Dbo;
using System;
using System.Collections.Generic;

namespace cancer_isp.Models
{
    public class ArtistWorkRegistrationModel
    {
        public string Artist { get; set; }

        public string Name { get; set; }

        public int LengthInSeconds { get; set; }

        public string RecordLabel { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }

        public string ImageUrl { get; set; }
    }
}
