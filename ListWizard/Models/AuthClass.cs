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

        }
    }
}
