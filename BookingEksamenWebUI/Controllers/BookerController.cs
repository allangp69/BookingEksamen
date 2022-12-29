using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamen.Controllers
{
    public class BookerController : Controller
    {
        private readonly ILogger<BookerController> _logger;
        private readonly BookerAPIHelper _bookerApiHelper;

        public BookerController(ILogger<BookerController> logger, BookerAPIHelper bookerApiHelper)
        {
            _logger = logger;
            _bookerApiHelper = bookerApiHelper;
        }

        public IActionResult Index()
        {
            var result = _bookerApiHelper.Authenticate("","");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}