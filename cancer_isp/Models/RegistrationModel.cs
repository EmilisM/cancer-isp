using System.ComponentModel.DataAnnotations;

namespace cancer_isp.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Repeated password is wrong")]
        public string RepeatPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}