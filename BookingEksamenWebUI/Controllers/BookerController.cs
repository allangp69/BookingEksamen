using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Controllers
{
    public class BookerController : Controller
    {
        private readonly ILogger<BookerController> _logger;
        private readonly IBookerAPIHelper _bookerApiHelper;

        public BookerController(IBookerAPIHelper bookerApiHelper, ILogger<BookerController> logger)
        {
            _logger = logger;
            _bookerApiHelper = bookerApiHelper;
        }

        public async Task<ActionResult> Index()
        {
            if (_bookerApiHelper is not IAuthenticationAPIHelper authenticationHelper)
            {
                throw new Exception("The API helper does not implement the IAuthenticationAPIHelper interface");
            }
            try
            {
                //Authentication does not work yet - so the Authenticate call is wrapped in a try/catch for now
                var result = await authenticationHelper.Authenticate("","", "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            var booker = _bookerApiHelper.GetBookersAsync().Result.FirstOrDefault(b => b.Email == User.Identity.Name);
            return View(booker);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}