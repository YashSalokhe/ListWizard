using System.ComponentModel.DataAnnotations;

namespace ListWizard.Models
{
    public class AuthClass
    {
        public class Login
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required]
            public string Password { get; set; } = null!;

            public bool RememberMe { get; set; }
        }

        public class Register
        {
            [Required]
            public string UserName { get; set; } = null!;
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;
            [Required]
            public string Password { get; set; } = null!;

            [Required]
            public string CompanyName { get; set; } = null!;

            [Required]
            [StringLength(10,MinimumLength =10,ErrorMessage ="Enter 10 digit valid phone number")]
            public string PhoneNumber { get; set; } = null!;
        }

        public class ForgotPasswordViewModel
        {
            
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;
        }

        public class ResetPasswordViewModel
        {
            [Required]
            public string Password { get; set; } = null!;
            [Required]
            [Compare(nameof(Password),ErrorMessage ="Password Should Match")]
            public string ConfirmPassword { get; set; } = null!;
        }
    }
}
