using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistAPIHelper _artistApiHelper;

        public ArtistController(IArtistAPIHelper artistApiHelper, ILogger<ArtistController> logger)
        {
            _logger = logger;
            _artistApiHelper = artistApiHelper;
        }

        public IActionResult Index()
        {
            if (_artistApiHelper is not IAuthenticationAPIHelper authenticationHelper)
            {
                throw new Exception("The API helper does not implement the IAuthenticationAPIHelper interface");
            }
            try
            {
                //Authentication does not work yet - so the Authenticate call is wrapped in a try/catch for now
                var result = authenticationHelper.Authenticate("","", "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}