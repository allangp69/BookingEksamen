using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Helpers;
using BookingEksamenWebUI.Models;

namespace BookingEksamenWebUI.Controllers
{
    public class HeavyWorkloadController : Controller
    {
        private readonly ILogger<HeavyWorkloadController> _logger;
        private readonly IHeavyWorkloadAPIHelper _heavyWorkloadApiHelper;

        public HeavyWorkloadController(IHeavyWorkloadAPIHelper heavyWorkloadApiHelper, ILogger<HeavyWorkloadController> logger)
        {
            _logger = logger;
            _heavyWorkloadApiHelper = heavyWorkloadApiHelper;
        }

        public async Task<IActionResult> HeavyWorkloadAsync()
        {
            if (_heavyWorkloadApiHelper is not IAuthenticationAPIHelper authenticationHelper)
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var returnValue = await _heavyWorkloadApiHelper.DoHeavyWorkloadAsync();
            stopWatch.Stop();
            var heavyWorkloadObject = new HeavyWorkloadObject(returnValue, stopWatch.Elapsed);
            return View(heavyWorkloadObject);
        }
        
        public IActionResult Heavy()
        {
            if (_heavyWorkloadApiHelper is not IAuthenticationAPIHelper authenticationHelper)
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var returnValue = _heavyWorkloadApiHelper.DoHeavyWorkload();
            stopWatch.Stop();
            var heavyWorkloadObject = new HeavyWorkloadObject(returnValue, stopWatch.Elapsed);
            return View(heavyWorkloadObject);
        }
        
        public async Task<IActionResult> NormalWorkloadAsync()
        {
            if (_heavyWorkloadApiHelper is not IAuthenticationAPIHelper authenticationHelper)
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
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var numberOfTimes = 1000;
            var returnValue = $"Calling DoNormalWorkloadAsync {numberOfTimes} times{Environment.NewLine}";
            for (var i = 0; i < 1000; i++)
            {
                returnValue += await _heavyWorkloadApiHelper.DoNormalWorkloadAsync();
            }
            stopWatch.Stop();
            var heavyWorkloadObject = new HeavyWorkloadObject(returnValue, stopWatch.Elapsed);
            return View(heavyWorkloadObject);
        }
        
        public IActionResult Normal()
        {
            if (_heavyWorkloadApiHelper is not IAuthenticationAPIHelper authenticationHelper)
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
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var numberOfTimes = 1000;
            var returnValue = $"Calling DoNormalWorkload {numberOfTimes} times{Environment.NewLine}";
            for (var i = 0; i < numberOfTimes; i++)
            {
                returnValue += _heavyWorkloadApiHelper.DoNormalWorkload();
            }
            stopWatch.Stop();
            var heavyWorkloadObject = new HeavyWorkloadObject(returnValue, stopWatch.Elapsed);
            return View(heavyWorkloadObject);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}