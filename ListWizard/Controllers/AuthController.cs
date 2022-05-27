using Microsoft.AspNetCore.Mvc;

namespace ListWizard.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
