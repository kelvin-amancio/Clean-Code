using System.ComponentModel.DataAnnotations;

namespace Clean_Architecture.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be least {2} and at max {1} characters long",MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string ReturnUrl { get; set; } = null!;
    }
}
