using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
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
            if (_isSignedInHelper.IsSignedIn(User))
            {
                if (User.IsInRole("Artist"))
                {
                    return RedirectToAction("Index", "Artist");    
                }
                //Commented out until identity roles are working as intended
                // if (User.IsInRole("Booker"))
                // {
                    return RedirectToAction("Index", "Booker");
                // }
            }
            return View();
        }
        
        public IActionResult ReadMore()
        {
            return View();
        }
        
        public IActionResult Contact()
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