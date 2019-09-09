using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Field {0} is needed")]
        [EmailAddress(ErrorMessage = "Invalid field {0} format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field {0} is needed")]
        [StringLength(100, ErrorMessage = "Field {0} must be {2} to {1} long", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirmation password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserModel
    {
        [Required(ErrorMessage = "Field{0} is needed")]
        [EmailAddress(ErrorMessage = "Invalid field {0} format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field{0} is needed")]
        [StringLength(100, ErrorMessage = "Invalid field {0} length")]
        public string Password { get; set; }
    }
}