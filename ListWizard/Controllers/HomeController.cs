using ListWizard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ListWizard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ListWizardContext context;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger , ListWizardContext context, UserManager<IdentityUser> _userManager)
        {
            _logger = logger;
            this.context = context;
            this._userManager = _userManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}