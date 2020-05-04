using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
