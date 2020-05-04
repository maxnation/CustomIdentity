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

        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        [Required]
        public string PasswordConfirm { get; set; }
    }
}
