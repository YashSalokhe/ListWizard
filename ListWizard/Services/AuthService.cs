using System.Security.Policy;

namespace ListWizard.Services
{
    public class AuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor http;
        private readonly ListWizarddbContext dbcontext;
        private readonly MailService mailService;

         
        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor http, ListWizarddbContext dbcontext, MailService mailService)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this.http = http;
            this.dbcontext = dbcontext;
            this.mailService = mailService;
        }

        public async Task<IdentityResult> RegisterUserAsync(Register register)
        {
            var registerNewUser = new User() 
            { UserName = register.UserName, 
              Email = register.Email,
              CompanyName = register.CompanyName,
              PhoneNumber = register.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(registerNewUser, register.Password);

            return result;
        }

        public async Task<string> LoginUserAsync(Login login)
        {
            string loginResult = string.Empty;
            var user = await _userManager.FindByEmailAsync(login.Email);
            

            if (user == null)
            {
                loginResult = "Invalid Email";
                return loginResult;
            }
                                                                                        
            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, login.RememberMe, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                loginResult = "Invalid Password";
                return loginResult;
            }
            else
            {
                loginResult = "Success";
                user.LastLoggedIn = DateTime.Now;
                await dbcontext.SaveChangesAsync();                     
                return loginResult;
            }

        }

        public async Task<string> ForgotPasswordAsync(string email)
        {
            var validUser = await _userManager.FindByEmailAsync(email);
            if (validUser == null)
            {
                return string.Empty;
            }
            else
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(validUser);              
                mailService.SendMail(email, token);
                return "ValidUser";
            }
            
        }

    }
}
