using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class ArtistRegistrationModel
    {
        public List<Occupation> Occupations { get; set; }

        [Required] public string Pseudonym { get; set; }

        [Required] public string Fullname { get; set; }

        [Required] public DateTime Birthdate { get; set; }

        [Required] public int OccupationId { get; set; }

        [Required] public DateTime OccupationStartDate { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string ImageUrl { get; set; }
    }
}