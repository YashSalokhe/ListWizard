using Microsoft.AspNetCore.Identity;

namespace ListWizard.Models
{
    public class User : IdentityUser
    {
        public string CompanyName { get; set; } = null!;
        public DateTime LastLoggedIn { get; set; }
    }
}
