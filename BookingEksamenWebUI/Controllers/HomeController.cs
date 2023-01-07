using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingEksamenWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIsSignedInHelper _isSignedInHelper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IIsSignedInHelper isSignedInHelper, ILogger<HomeController> logger)
        {
            _isSignedInHelper = isSignedInHelper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if (!await _isSignedInHelper.IsSignedIn(User))
            {
                return View();
            }

            if (await _isSignedInHelper.IsInRole(User, "Artist"))
            {
                return RedirectToAction("Index", "Artist");
            }
            if (await _isSignedInHelper.IsInRole(User, "Booker"))
            {
                return RedirectToAction("Index", "Booker");
            }
            return View();
        }

        public async Task<IActionResult> ReadMore()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}