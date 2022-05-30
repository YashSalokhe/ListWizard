using Microsoft.AspNetCore.Mvc;

namespace ListWizard.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            this._authService = authService;
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
        public async Task<IActionResult> ForgotPassword(ForgotPasswordView forgotPassword)
        {
            string result= await _authService.ForgotPasswordAsync(forgotPassword.Email);
            return RedirectToAction("ResetPassword");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
