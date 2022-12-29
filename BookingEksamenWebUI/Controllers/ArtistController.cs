using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly ArtistAPIHelper _artistApiHelper;

        public ArtistController(ILogger<ArtistController> logger, ArtistAPIHelper artistApiHelper)
        {
            _logger = logger;
            _artistApiHelper = artistApiHelper;
        }

        public IActionResult Index()
        {
            var result = _artistApiHelper.Authenticate("","");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}