using System.ComponentModel.DataAnnotations;
using cancer_isp.Models.Dbo;

namespace cancer_isp.Models
{
    public class AdminRolesModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public UserRoleEnum Role { get; set; }
    }
}