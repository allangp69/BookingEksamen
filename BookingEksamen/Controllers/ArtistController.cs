using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly APIHelper _apiHelper;

        public ArtistController(ILogger<ArtistController> logger, APIHelper apiHelper)
        {
            _logger = logger;
            _apiHelper = apiHelper;
        }

        public IActionResult Index()
        {
            var result = _apiHelper.Authenticate("","");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}