using Microsoft.AspNetCore.Mvc;

namespace ListWizard.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserManager<User> _userManager;

        public AuthController(AuthService authService, UserManager<User> _userManager)
        {
            this._authService = authService;
            this._userManager = _userManager;
        }
        public ViewResult Index()
        {
            return View();
        }
                                                            
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {


            string authResult = await _authService.LoginUserAsync(login);
            if (authResult == "Success")
            {
                return RedirectToAction("CreateNewList","Wizard");
            }
            else
            {
                ViewBag.message = authResult;
                return View(login);
            }
        }

        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(register);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

            }
            return View(register);
        }

        public ViewResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var sendEmail = await _authService.ForgotPasswordAsync(forgotPassword.Email);
                    //var validUser = await _userManager.FindByEmailAsync(forgotPassword.Email);
                    //var token = await _userManager.GeneratePasswordResetTokenAsync(validUser);
                    //var passwordresetLink = Url.Action("ResetPassword", "Auth", new { email = forgotPassword.Email, token = token }, Request.Scheme);
                    return RedirectToAction("ResetPassword");

            }
            else
            { return View();}
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            return View();
        }
    }
}
