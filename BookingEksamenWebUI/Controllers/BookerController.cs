using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
{
    public class BookerController : Controller
    {
        private readonly ILogger<BookerController> _logger;
        private readonly APIHelper _apiHelper;

        public BookerController(ILogger<BookerController> logger, APIHelper apiHelper)
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