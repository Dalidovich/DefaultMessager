using DefaultMessager.DAL;
using DefaultMessager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DefaultMessager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("PostIcons", "Post");
        }

        public IActionResult ReloadBD()
        {
            HttpContext.RequestServices.GetService<MessagerDbContext>().UpdateDatabase();

            return RedirectToAction("PostIcons", "Post");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}