using System.ComponentModel.DataAnnotations;

namespace cancer_isp.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [EmailAddress] public string Email { get; set; }
    }
}