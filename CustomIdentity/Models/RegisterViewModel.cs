using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Required]
        public string PasswordConfirm { get; set; }
    }
}
