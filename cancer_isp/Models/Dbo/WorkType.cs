using System.Collections.Generic;

namespace cancer_isp.Models.Dbo
{
    public partial class WorkType
    {
        public WorkType()
        {
            Genre = new HashSet<Genre>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Genre> Genre { get; set; }
    }
}
